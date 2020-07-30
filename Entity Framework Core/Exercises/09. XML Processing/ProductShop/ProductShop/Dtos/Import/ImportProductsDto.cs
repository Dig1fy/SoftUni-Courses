using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    [XmlType("Product")] //in eg like the models/class Product
    public class ImportProductsDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyerId")]
        public int? BuyerId { get; set; }

        [XmlElement("sellerId")]
        public int SellerId { get; set; }

    }
}
