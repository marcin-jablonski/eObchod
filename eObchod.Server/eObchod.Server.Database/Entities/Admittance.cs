using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eObchod.Server.Database.Entities
{
    public class Admittance
    {
        [ForeignKey("PatientPesel")]
        public Patient Patient { get; set; }

        [Key]
        [Column(Order = 3)]
        public string PatientPesel { get; set; }

        public Ward Ward { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Ward")]
        public int WardId { get; set; }

        [Key]
        [ForeignKey("Ward"), Column(Order = 1)]
        public int BlockId { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime AdmittanceDate { get; set; }

        public DateTime DischargeDate { get; set; }

        public bool Current { get; set; }
    }
}
