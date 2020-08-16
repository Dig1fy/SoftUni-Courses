using SoftJail.Data.Models;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType(nameof(Prisoner))]
    public class ExportInboxPrisonerDto
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("IncarcerationDate")]
        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public ExportMessagesDto[] EncryptedMessages { get; set; }

    }

    [XmlType("Message")]
    public class ExportMessagesDto
    {
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}
