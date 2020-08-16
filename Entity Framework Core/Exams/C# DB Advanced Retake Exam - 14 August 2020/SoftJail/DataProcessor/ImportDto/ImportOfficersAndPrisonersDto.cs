using SoftJail.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType(nameof(Officer))]
    public class ImportOfficersAndPrisonersDto
    {
        [XmlElement("Name")]
        [Required, MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [XmlElement("Money")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        [XmlElement("Position")]
        [Required]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        [Required]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public ImportXmlPrisonersDto[] Prisoners { get; set; }

    }

    [XmlType(nameof(Prisoner))]
    public class ImportXmlPrisonersDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
