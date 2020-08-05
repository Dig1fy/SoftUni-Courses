using MusicHub.Data.Models;
using System.Xml.Serialization;

namespace MusicHub.DataProcessor.ImportDtos
{
    [XmlType(nameof(Performer))]
    public class ImportPerformerDto
    {
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }

        [XmlElement("NetWorth")]
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
