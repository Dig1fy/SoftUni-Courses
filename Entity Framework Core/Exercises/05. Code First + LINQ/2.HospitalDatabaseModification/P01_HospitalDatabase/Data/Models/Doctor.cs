using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }
        public int DoctorId { get; set; }

        [MaxLength(GlobalConstants.DoctorName)]
        public string Name { get; set; }

        [MaxLength(GlobalConstants.DoctorSpecialty)]
        public string Specialty { get; set; }

        public virtual  ICollection<Visitation> Visitations { get; set; }
    }
}
