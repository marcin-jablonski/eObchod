using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eObchod.Server.Database.Entities
{
    public class MedicineHistoryItem
    {
        public Patient Patient { get; set; }

        [Key, ForeignKey("Patient"), Column(Order = 1)]
        public string PatientPesel { get; set; }

        [Key, Column(Order = 3)]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Medicine Medicine { get; set; }

        [Key, ForeignKey("Medicine"), Column(Order = 2)]
        public string ATC { get; set; }

        public string Note { get; set; }
    }
}