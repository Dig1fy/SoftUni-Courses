using Microsoft.EntityFrameworkCore.Diagnostics;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Loader;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main()
        {
            var context = new SoftUniContext();

            //Task 3 - Employee Full Information
            //Console.WriteLine(GetEmployeesFullInformation(context));

            //Task 4 - Employees with Salary Over 50 000
            //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));

            //Task 5 - Employees from Research and Development
            //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));

            //Task 6 - Adding a New Address and Updating Employee
            //Console.WriteLine(AddNewAddressToEmployee(context));

            //Task 7 - Employees and Projects
            //Console.WriteLine(GetEmployeesInPeriod(context));

            //Task 8 - Addresses by Town
            //Console.WriteLine(GetAddressesByTown(context));

            //Task 9 - Employee 147
            //Console.WriteLine(GetEmployee147(context));

            //Task 10 - Departments with More Than 5 Employees
            //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));

            //Task 11 - Find Latest 10 Projects
            //Console.WriteLine(GetLatestProjects(context));

            //Task 12 - Increase Salaries
            //Console.WriteLine(IncreaseSalaries(context));

            //Task 13 - Find Employees by First Name Starting with "Sa"
            //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));

            //Task 14 - Delete Project by Id
            //Console.WriteLine(DeleteProjectById(context));

            //Task 15 - Remove Town
            Console.WriteLine(RemoveTown(context));
        }

        //----------Task 3 - Employee Full Information----------
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .OrderBy(x => x.EmployeeId)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    middleName = x.MiddleName,
                    jobTitle = x.JobTitle,
                    salary = x.Salary
                }).ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.firstName} {emp.lastName} {emp.middleName} {emp.jobTitle} {emp.salary:F2}");
            }

            return sb.ToString().Trim();
        }

        //----------Task 4 - Employees with Salary Over 50 000----------
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    salary = x.Salary
                }).ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.firstName} - {emp.salary:F2}");
            }

            return sb.ToString().Trim();
        }

        //----------Task 5 - Employees from Research and Development----------
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    departmentName = e.Department.Name,
                    salary = e.Salary
                })
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.firstName} {emp.lastName} from {emp.departmentName} - ${emp.salary:F2}");
            }

            return sb.ToString().Trim();
        }

        //----------Task 6 - Adding a New Address and Updating Employee----------
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {

            var employee = context
                .Employees
                .Where(e => e.LastName == "Nakov")
                .FirstOrDefault();

            var newAddress = new Address() { AddressText = "Vitoshka 15", TownId = 4 };

            employee.Address = newAddress;

            context.SaveChanges();

            var addresses = context
                .Employees
                .OrderByDescending(a => a.AddressId)
                .Take(10)
                .Select(a => new
                {
                    output = a.Address.AddressText
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var addr in addresses)
            {
                sb.AppendLine($"{addr.output}");
            }

            return sb.ToString().Trim();
        }

        //----------Task 7 - Employees and Projects----------
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var startDate = 2001;
            var endDate = 2003;
            var sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(ep => ep.EmployeesProjects.
                            Any(p => p.Project.StartDate.Year >= startDate && p.Project.StartDate.Year <= endDate))
                .Take(10)
                .Select(e => new
                {
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    managerFirstName = e.Manager.FirstName,
                    managerLastName = e.Manager.LastName,
                    assignedProjects = e.EmployeesProjects
                        .Select(p => new
                        {
                            p.Project.Name,
                            p.Project.StartDate,
                            p.Project.EndDate,

                        })
                })
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.firstName} {emp.lastName} - Manager: {emp.managerFirstName} {emp.managerLastName}");

                foreach (var project in emp.assignedProjects)
                {
                    var projectStartDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    var projectEndDate = project.EndDate is null ? "not finished" : project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                    sb.AppendLine($"--{project.Name} - {projectStartDate} - {projectEndDate}");
                }
            }

            return sb.ToString().Trim();
        }

        //----------Task 8 - Addresses by Town----------
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context
                .Addresses
                .OrderByDescending(e => e.Employees.Count())
                .ThenBy(t => t.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    addressText = a.AddressText,
                    townName = a.Town.Name,
                    employeesCount = a.Employees.Count()
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var addr in addresses)
            {
                sb.AppendLine($"{addr.addressText}, {addr.townName} - {addr.employeesCount} employees");
            }

            return sb.ToString().Trim();
        }

        //----------Task 9 - Employee 147----------
        public static string GetEmployee147(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(x => x.EmployeeId == 147)
                .Select(e => new
                {
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    jobTitle = e.JobTitle,
                    projecs = e.EmployeesProjects
                    .Select(p => p.Project.Name)
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.firstName} {emp.lastName} - {emp.jobTitle}");

                foreach (var p in emp.projecs.OrderBy(pr => pr))
                {
                    sb.AppendLine($"{p}");
                }
            }

            return sb.ToString().Trim();
        }

        //----------Task 10 - Departments with More Than 5 Employees----------
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context
                .Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(x => x.Employees.Count())
                .ThenBy(dn => dn.Name)
                .Select(dm => new
                {
                    departmentName = dm.Name,
                    departmentManagerFirstName = dm.Manager.FirstName,
                    departmentManagerLastName = dm.Manager.LastName,
                    employees = dm.Employees
                        .Select(e => new
                        {
                            empFirstname = e.FirstName,
                            empLastName = e.LastName,
                            empJobTitle = e.JobTitle
                        })
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var dep in departments)
            {
                sb.AppendLine($"{dep.departmentName} - {dep.departmentManagerFirstName} {dep.departmentManagerLastName}");

                foreach (var e in dep.employees.OrderBy(em => em.empFirstname).ThenBy(em => em.empLastName))
                {
                    sb.AppendLine($"{e.empFirstname} {e.empLastName} - {e.empJobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        //----------Task 11 - Find Latest 10 Projects----------
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context
                .Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    projectName = x.Name,
                    projectDescription = x.Description,
                    startDate = x.StartDate
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var p in projects)
            {
                sb
                    .AppendLine($"{p.projectName}")
                    .AppendLine($"{p.projectDescription}")
                    .AppendLine($"{p.startDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }

            return sb.ToString().Trim();
        }

        //----------Task 12 - Increase Salaries----------
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var desiredDepartments = new[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employees = context
                .Employees
                .Where(e => desiredDepartments.Contains(e.Department.Name));

            foreach (var e in employees)
            {
                e.Salary *= 1.12M;
            }

            context.SaveChanges();

            var employeesWithIncreasedSalary = employees
                .Select(e => new
                {
                    firstName = e.FirstName,
                    lastName = e.LastName,
                    salary = e.Salary
                })
                .OrderBy(e => e.firstName)
                .ThenBy(e => e.lastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var em in employeesWithIncreasedSalary)
            {
                sb.AppendLine($"{em.firstName} {em.lastName} (${em.salary:F2})");
            }

            return sb.ToString().Trim();
        }

        //----------Task 13 - Find Employees by First Name Starting with "Sa" -- 66 out of 100 in Judge... No idea why----------
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .Select(em => new
                {
                    firstName = em.FirstName,
                    lastName = em.LastName,
                    jobTitle = em.JobTitle,
                    salary = em.Salary
                })
                .ToList();

            var sb = new StringBuilder();

            if (!employees.Any())
            {
                sb.AppendLine($"{string.Empty}");
            }

            foreach (var e in employees.OrderBy(x => x.firstName).ThenBy(x => x.lastName))
            {
                sb.AppendLine($"{e.firstName} {e.lastName} - {e.jobTitle} - (${e.salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //----------Task 14 - Delete Project by Id----------
        public static string DeleteProjectById(SoftUniContext context)
        {
            var idToDelete = 2;
            //First step - select and delete from the many-to-many table
            var projectToDeleteFromTable_EP = context
                .EmployeesProjects
                .Where(p => p.ProjectId == idToDelete)
                .ToList();

            context.EmployeesProjects.RemoveRange(projectToDeleteFromTable_EP);

            //Second step - delete from the Projects table
            var projectToDeleteFromTable_Projects = context
                .Projects
                .Where(x => x.ProjectId == idToDelete)
                .ToList();

            context.Projects.RemoveRange(projectToDeleteFromTable_Projects);
            context.SaveChanges();
            //Select the remaining projects
            var projects = context
                .Projects
                .Take(10)
                .Select(x=>x.Name)
                .ToList();

            var sb = new StringBuilder();

            //append first 10 projects to the sb
            foreach (var p in projects)
            {
                sb.AppendLine($"{p}");
            }

            return sb.ToString().Trim();
        }

        //----------Task 15 - Remove Town----------
        public static string RemoveTown(SoftUniContext context)
        {
            var townName = "Seattle";

            var townToDelete = context
                .Towns
                .Where(t => t.Name == townName)
                .FirstOrDefault();

            var addresses = context
                .Addresses
                .Where(a => a.TownId == townToDelete.TownId)
                .ToList();

            foreach (var adr in addresses)
            {
                var employees = context
                    .Employees
                    .Where(e => e.AddressId == adr.AddressId)
                    .ToList();

                foreach (var emp in employees)
                {
                    emp.AddressId = null;
                }

                context.Addresses.Remove(adr);
            }

            context.Towns.Remove(townToDelete);

            context.SaveChanges();

            return $"{addresses.Count()} addresses in {townName} were deleted";
        }
    }
}