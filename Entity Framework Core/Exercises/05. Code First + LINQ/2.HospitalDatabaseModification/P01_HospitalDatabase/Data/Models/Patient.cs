using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {

        public Patient()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
            this.Diagnoses = new HashSet<Diagnose>();
            this.Visitations = new HashSet<Visitation>();
        }
        public int PatientId { get; set; }

        [MaxLength(GlobalConstants.PatientFistName)]
        public string FirstName { get; set; }

        [MaxLength(GlobalConstants.PatientLastName)]
        public string LastName { get; set; }

        [MaxLength(GlobalConstants.PatientAddress)]
        public string Address { get; set; }

        [MaxLength(GlobalConstants.PatientEmail)]
        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }

        public virtual  ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }

    }
}
