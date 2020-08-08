using MusicHub.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType(nameof(Performer))]
    public class XmlImportSongsPerformersDto
    {
        [XmlElement("FirstName")]
        [Required, MinLength(3), MaxLength(20)]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        [Required, MinLength(3), MaxLength(20)]
        public string LastName { get; set; }

        [XmlElement("Age")]
        [Range(18,70)]
        public int Age { get; set; }

        [XmlElement("NetWorth")]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal NetWorth { get; set; }

        [XmlArray("PerformersSongs")]
        public PerformerSongsDto[] PerformersSongs { get; set; }
    }

    [XmlType(nameof(Song))]
    public class PerformerSongsDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
