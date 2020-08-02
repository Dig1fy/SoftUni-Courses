using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop.DataProcessor.ImportDto
{
    public class ImportAuthorDto
    {
        [Required, MinLength(3), MaxLength(30)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(30)]
        public string LastName { get; set; }

        [RegularExpression("^(\\d{3})-(\\d{3})-(\\d{4})$")]
        public string Phone { get; set; }

        [EmailAddress, Required]
        public string Email { get; set; }

        public AuthorBooks[] Books { get; set; }
    }

    public class AuthorBooks
    {
        public int? Id { get; set; }
    }
}
