using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Data.Models
{
    public class Customer
    {
      
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}