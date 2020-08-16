namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";
        private const string SuccessfullyAddedDepartmentWithCells = "Imported {0} with {1} cells";
        private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";
        private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var depDtos = JsonConvert.DeserializeObject<ImportDepartmentsAndCells[]>(jsonString);
            var sb = new StringBuilder();
            var listOfDeps = new List<Department>();

            foreach (var depDto in depDtos)
            {
                if (!IsValid(depDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var department = new Department
                {
                    Name = depDto.Name
                };

                var listOfCells = new List<Cell>();
                var isValid = true;

                foreach (var cell in depDto.Cells)
                {
                    
                    if (!IsValid(cell))
                    {
                        sb.AppendLine(ErrorMessage);
                        listOfCells.Clear();
                        isValid = false;
                        break;
                       
                    }

                    listOfCells.Add(new Cell
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow
                    });
                }

                if (!isValid)
                {
                    isValid = true;
                    continue;
                }

                if (listOfCells.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var cell in listOfCells)
                {
                    department.Cells.Add(cell);
                }


                listOfDeps.Add(department);
                sb.AppendLine(string.Format(SuccessfullyAddedDepartmentWithCells, department.Name, department.Cells.Count));
            }

            context.Departments.AddRange(listOfDeps);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDtos = JsonConvert.DeserializeObject<ImportPrisonersMailsDto[]>(jsonString);
            var sb = new StringBuilder();
            var listOfPrisoners = new List<Prisoner>();

            foreach (var prisDto in prisonersDtos)
            {
                if (!IsValid(prisDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarcerationDate;
                bool isIncarcerationDateValid = DateTime.TryParseExact(prisDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                DateTime releaseDate;
                bool isReleaseDateValid = DateTime.TryParseExact(prisDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var prisoner = new Prisoner
                {
                    FullName = prisDto.FullName,
                    Nickname = prisDto.Nickname,
                    Age = prisDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisDto.Bail == null ? null : prisDto.Bail,
                    CellId = prisDto.CellId
                };

                var isEntityValid = true;

                foreach (var mailDto in prisDto.Mails)
                {
                  var currentMail = new Mail
                   {
                       Description = mailDto.Description,
                       Sender = mailDto.Sender,
                       Address = mailDto.Address
                   };

                    if (!IsValid(currentMail))
                    {
                        sb.AppendLine(ErrorMessage);
                        isEntityValid = false;
                        break;
                    }

                    prisoner.Mails.Add(currentMail);
                }

                if (!isEntityValid)
                {
                    continue;
                }

                listOfPrisoners.Add(prisoner);
                sb.AppendLine(string.Format(SuccessfullyImportedPrisoner, prisoner.FullName, prisoner.Age));
            }

            context.Prisoners.AddRange(listOfPrisoners);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOfficersAndPrisonersDto[]), new XmlRootAttribute("Officers"));
            StringBuilder sb = new StringBuilder();
            var listOfOfficers = new List<Officer>();
            var listOfAllPrisoners = new List<OfficerPrisoner>();

            using (var stringReader = new StringReader(xmlString))
            {
                var officersDtos = (ImportOfficersAndPrisonersDto[])xmlSerializer.Deserialize(stringReader);

                foreach (var offDto in officersDtos)
                {
                    if (!IsValid(offDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isPositionValid = Enum.TryParse(offDto.Position, out Position position);
                    var isWeaponValid = Enum.TryParse(offDto.Weapon, out Weapon weapon);

                    if (!isPositionValid || !isWeaponValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var officer = new Officer
                    {
                        FullName = offDto.Name,
                        Salary = offDto.Money,
                        Position = position,
                        Weapon = weapon,
                        DepartmentId = offDto.DepartmentId
                    };

                    var tempListOfOfficersPrisoners = new List<OfficerPrisoner>();

                    foreach (var prisoner in offDto.Prisoners)
                    {
                        var prisonersOfficer = new OfficerPrisoner
                        {
                            Officer = officer,
                            PrisonerId = prisoner.Id
                        };

                        tempListOfOfficersPrisoners.Add(prisonersOfficer);
                        listOfAllPrisoners.Add(prisonersOfficer);
                    }

                    listOfOfficers.Add(officer);
                    sb.AppendLine(string.Format(SuccessfullyImportedOfficer, officer.FullName, tempListOfOfficersPrisoners.Count));

                }

                context.Officers.AddRange(listOfOfficers);
                context.OfficersPrisoners.AddRange(listOfAllPrisoners);
                context.SaveChanges();

                return sb.ToString().Trim();
            }
        }


        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}