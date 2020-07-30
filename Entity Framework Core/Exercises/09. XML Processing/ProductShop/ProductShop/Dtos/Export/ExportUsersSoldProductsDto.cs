using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
   [XmlType("User")]
    public class ExportUserSoldProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName  { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public SoldProduct[]  SoldProducts { get; set; }
    }


    [XmlType("Product")]
    public class SoldProduct
    {
        [XmlElement("name")]
        public string Name  { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
