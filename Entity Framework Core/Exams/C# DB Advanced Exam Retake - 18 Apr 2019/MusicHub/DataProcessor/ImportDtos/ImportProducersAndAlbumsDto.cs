using System.ComponentModel.DataAnnotations;

namespace MusicHub.DataProcessor.ImportDtos
{
    public class ImportProducersAndAlbumsDto
    {
        [Required, MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [RegularExpression("^([A-Z]{1}[a-z]+) ([A-Z]{1}[a-z]+)$")]
        public string Pseudonym { get; set; }

        [RegularExpression(@"^\+359 \d{3} \d{3} \d{3}$")]
        public string PhoneNumber { get; set; }

        public AlbumsDto[] Albums { get; set; }
    }

    public class AlbumsDto
    {
        [Required, MinLength(3), MaxLength(40)]
        public string Name { get; set; }

        [Required]
        public string ReleaseDate { get; set; }
    }
}