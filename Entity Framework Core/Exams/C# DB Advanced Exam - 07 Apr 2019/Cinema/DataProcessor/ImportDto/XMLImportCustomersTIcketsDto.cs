using Cinema.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType(nameof(Customer))]
    public class XMLImportCustomersTIcketsDto
    {
        [Required, MinLength(3), MaxLength(20)]
        [XmlElement("FirstName")]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        [XmlElement("LastName")]
        public string LastName { get; set; }

        [Range(12,110)]
        [XmlElement("Age")]
        public int Age { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [XmlElement("Balance")]
        public decimal Balance { get; set; }

        [XmlArray("Tickets")]
        public CustomerTickets[] Tickets { get; set; }
    }

    [XmlType(nameof(Ticket))]
    public class CustomerTickets
    {
        [XmlElement("ProjectionId")]
        public int ProjectionId { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [XmlElement("Price")]
        public decimal Price { get; set; }

    }
}