using Cinema.Data.Models;
using System;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{

    [XmlType(nameof(Projection))]
    public class ImportProjectionsXmlDto
    {
        [XmlElement("MovieId")]
        public int MovieId { get; set; }

        [XmlElement("HallId")]
        public int HallId { get; set; }

        [XmlElement("DateTime")]
        public string DateTime { get; set; }
    }
}