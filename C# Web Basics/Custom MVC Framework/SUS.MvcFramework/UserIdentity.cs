using System.ComponentModel.DataAnnotations;

namespace SUS.MvcFramework
{
    //The id could be int so we will give the type from outside
    public class IdentityUser<T>
    {
        public T Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public IdentityRole Role{ get; set; }
    }
}
