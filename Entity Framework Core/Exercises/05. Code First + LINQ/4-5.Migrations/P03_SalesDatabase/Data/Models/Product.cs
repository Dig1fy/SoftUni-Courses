using P03_SalesDatabase.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
        }

        [Key]
        public int ProductId { get; set; }

        //Constant values come from Common -> GlobalConstants (public static)
        [MaxLength(GlobalConstants.ProductNameMaxLength)] 
        public string Name { get; set; }

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        [MaxLength(GlobalConstants.ProductDescriptionMaxLength)]
        public string Description { get; set; }

        //One-to-many relation with Sale.
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
