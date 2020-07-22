using Newtonsoft.Json;

namespace ProductShop.DTO.Products
{
    public class ListOfProductsInRangeDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("seller")]
        public string SellerName { get; set; }

    }
}
