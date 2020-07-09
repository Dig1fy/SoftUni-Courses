using P03_SalesDatabase.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P03_SalesDatabase.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }

        [Key]
        public int CustomerId { get; set; }

        [MaxLength(GlobalConstants.CustomerNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.CustomerEmailMaxLength)]
        public string Email { get; set; }

        public string CreditCardNumber { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}