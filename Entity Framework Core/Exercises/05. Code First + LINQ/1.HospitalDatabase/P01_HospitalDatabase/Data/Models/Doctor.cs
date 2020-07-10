using System.Collections;
using System.Collections.Generic;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }
        public int DoctorId { get; set; }

        public string Name { get; set; }

        public string Specialty { get; set; }

        public virtual  ICollection<Visitation> Visitations { get; set; }
    }
}
