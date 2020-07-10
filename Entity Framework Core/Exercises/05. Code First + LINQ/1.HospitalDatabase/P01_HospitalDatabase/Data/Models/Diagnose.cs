using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {
        public int DiagnoseId { get; set; }

        [MaxLength(GlobalConstants.DiagnoseName)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.DiagnoseComments)]
        public string Comments { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

    }
}
