namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Text;
    using TeisterMask.Data.Models;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            //We need string builder for the output
            var sb = new StringBuilder();
            var listOfProjects = new List<Project>();

            var xmlSerializer = new XmlSerializer(typeof(XmlImportProjectsDto[]), new XmlRootAttribute("Projects"));

            using (var stringReader = new StringReader(xmlString))
            {
                var projDtos = (XmlImportProjectsDto[])xmlSerializer.Deserialize(stringReader);

                foreach (var projDto in projDtos)
                {
                    if (!IsValid(projDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime openDateProject;
                    var isOpenDateProjectValid = DateTime.TryParseExact(projDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out openDateProject);

                    if (!isOpenDateProjectValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime? dueDateProject;

                    if (!string.IsNullOrWhiteSpace(projDto.DueDate))
                    {
                        DateTime nonNullableDate;
                        var isDueDateProjectValid = DateTime.TryParseExact(projDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nonNullableDate);

                        if (!isDueDateProjectValid)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        dueDateProject = nonNullableDate;
                    }
                    else
                    {
                        dueDateProject = null;
                    }

                    //We've passed all validations for project and could create a new entity
                    var project = new Project
                    {
                        Name = projDto.Name,
                        OpenDate = openDateProject,
                        DueDate = dueDateProject
                    };

                    //We need to validate the tasks as well

                    foreach (var taskDto in projDto.Tasks)
                    {
                        if (!IsValid(taskDto))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        DateTime openDateTask;
                        var isOpenDateTaskValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out openDateTask);

                        if (!isOpenDateTaskValid)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        DateTime dueDateTask;
                        var isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dueDateTask);

                        if (!isTaskDueDateValid)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        if (openDateTask < openDateProject || dueDateTask > dueDateProject)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        //Once we've passed all task validations, we could create a new Task entity and add it to the project
                        var task = new Task
                        {
                            Name = taskDto.Name,
                            OpenDate = openDateTask,
                            DueDate = dueDateTask,
                            ExecutionType = (ExecutionType)taskDto.ExecutionType,
                            LabelType = (LabelType)taskDto.LabelType
                        };

                        project.Tasks.Add(task);
                    }

                    listOfProjects.Add(project);
                    sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
                }

                context.Projects.AddRange(listOfProjects);
                context.SaveChanges();

                return sb.ToString().Trim();
            }
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var listOfEmployees = new List<Employee>();

            var employeeDtos = JsonConvert.DeserializeObject<JsonImportEmployeesDto[]>(jsonString);

            foreach (var empDto in employeeDtos)
            {
                if (!IsValid(empDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = empDto.Username,
                    Email = empDto.Email,
                    Phone = empDto.Phone
                };

                foreach (var taskId in empDto.Tasks.Distinct())
                {
                    var desiredTask = context.Tasks.FirstOrDefault(x => x.Id == taskId);

                    if (desiredTask == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask
                    {
                        Employee = employee,
                        Task = desiredTask
                    });
                }

                listOfEmployees.Add(employee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(listOfEmployees);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}