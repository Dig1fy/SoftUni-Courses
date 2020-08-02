using BookShop.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType (nameof(Book))]
    public class ImportBookDto
    {

        // We check with the same constraint from the Models. Now  we can set all the validations because we're about to import data,
        // not create the DB. We check for the validation with IsValid method in the Main.

        [Required, MinLength(3), MaxLength(30)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Range (1,3)]
        [XmlElement("Genre")]
        public int Genre { get; set; }

        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        [XmlElement("Price")]
        public decimal Price { get; set; }

        [Range(50, 5000)]
        [XmlElement("Pages")]
        public int Pages { get; set; }

        //We need the plain text and then try to parse the input data into the desired format.
        [Required]
        [XmlElement("PublishedOn")]
        public string PublishedOn { get; set; }


    }
}
