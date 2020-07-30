using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("User")]
    public class ImportUserDto
    {
        //XML is b*****t and it's case sensitive so we need to explicitly say that firstName is actually FirstName

        [XmlElement("FirstName")]
        public string Firstname { get; set; }

        [XmlElement("LastName")]
        public string LastName { get; set; }

        [XmlElement("Age")]
        public int? Age { get; set; }


    }
}
