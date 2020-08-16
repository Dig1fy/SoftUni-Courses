using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentsAndCells
    {
        [Required, MinLength(3), MaxLength(25)]
        public string Name { get; set; }

        public ImportCellsDto[] Cells { get; set; }
    }

    public class ImportCellsDto
    {
        [Range(1,1000)]
        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }
    }
}
