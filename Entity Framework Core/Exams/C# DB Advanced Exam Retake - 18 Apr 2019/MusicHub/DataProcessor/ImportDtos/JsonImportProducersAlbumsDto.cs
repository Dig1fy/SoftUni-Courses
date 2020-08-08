using System.ComponentModel.DataAnnotations;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class JsonImportProducersAlbumsDto
    {
        [Required, MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+$")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^\+359 \d{3} \d{3} \d{3}$")]
        public string PhoneNumber { get; set; }

        public ProducerAlbumsDto[] Albums { get; set; }
    }

    public class ProducerAlbumsDto
    {
        [Required, MinLength(3), MaxLength(40)]
        public string Name { get; set; }
        
        [Required]
        public string ReleaseDate { get; set; }

    }
}