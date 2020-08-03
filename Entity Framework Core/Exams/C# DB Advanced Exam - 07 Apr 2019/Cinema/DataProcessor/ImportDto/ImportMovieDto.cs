using Cinema.Data.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cinema.DataProcessor.ImportDto
{
    public class ImportMovieDto
    {
        [Required, MinLength(3), MaxLength(20)]
        public string Title { get; set; }

        public string Genre { get; set; }
                
        public TimeSpan Duration { get; set; }

        [Range(1,10)]
        public double Rating { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string Director { get; set; }
    }
}