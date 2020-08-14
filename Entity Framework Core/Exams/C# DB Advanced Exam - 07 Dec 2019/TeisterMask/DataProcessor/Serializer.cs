namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .ToArray() //Comment this one when testing locally. JUDGE requires materialization before ordering - InMemory issue...
                .Where(x => x.Tasks.Count > 0)
                .OrderByDescending(q => q.Tasks.Count)
                .ThenBy(q => q.Name)
                .Select(y => new ExportProjectsDto
                {
                    TasksCount = y.Tasks.Count,
                    ProjectName = y.Name,
                    HasEndDate = y.DueDate.HasValue ? "Yes" : "No",
                    Tasks = y.Tasks
                    .OrderBy(h => h.Name)
                    .Select(b => new TasksDto
                    {
                        Name = b.Name,
                        Label = b.LabelType.ToString()
                    })
                    .ToArray()
                })
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProjectsDto[]), new XmlRootAttribute("Projects"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            var sb = new StringBuilder();

            using (var stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, projects, namespaces);
            }

            return sb.ToString().Trim();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToArray()//Comment this one when testing locally. JUDGE requires materialization before ordering - InMemory issue...
                .Where(x => x.EmployeesTasks.Any(y => y.Task.OpenDate >= date))
                .Select(b => new
                {
                    Username = b.Username,
                    Tasks = b.EmployeesTasks
                    .Where(a => a.Task.OpenDate >= date)
                    .OrderByDescending(g => g.Task.DueDate)
                    .ThenBy(g => g.Task.Name)                    
                    .Select(z => new
                    {
                        TaskName = z.Task.Name,
                        OpenDate = z.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = z.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = z.Task.LabelType.ToString(),
                        ExecutionType = z.Task.ExecutionType.ToString()
                    })
                    .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Length)       
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return jsonResult;

        }
    }
}