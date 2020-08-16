namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(y => new
                    {
                        OfficerName = y.Officer.FullName,
                        Department = y.Officer.Department.Name
                    })
                    .OrderBy(q => q.OfficerName)
                    .ToArray()
                    ,
                    TotalOfficerSalary = decimal.Parse(x.PrisonerOfficers.Sum(b => b.Officer.Salary).ToString("f2"))
                })
                .OrderBy(h => h.Name)
                .ThenBy(h => h.Id)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return jsonResult.ToString().Trim();
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var listOfPrisoners = prisonersNames.Split(",").ToList();

            var prisoners = context.Prisoners
                .Where(p => listOfPrisoners.Contains(p.FullName))
                .Select(x => new ExportInboxPrisonerDto
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    EncryptedMessages = x.Mails.Select(y => new ExportMessagesDto
                    {
                        Description = ReverseString(y.Description)
                    })

                    .ToArray()
                })
                .OrderBy(a=>a.Name)
                .ThenBy(a=>a.Id)
                .ToArray();


            var sb = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(ExportInboxPrisonerDto[]), new XmlRootAttribute("Prisoners"));

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (var stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, prisoners, namespaces);
            }

            return sb.ToString().Trim();

        }

        private static string ReverseString(string x)
        {
            var sb = new StringBuilder();

            for (int i = x.Length - 1; i >= 0; i--)
            {
                sb.Append(x[i]);
            }

            return sb.ToString();
        }
    }
}