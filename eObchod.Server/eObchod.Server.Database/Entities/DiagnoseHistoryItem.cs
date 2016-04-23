using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eObchod.Server.Database.Entities
{
    public class DiagnoseHistoryItem
    {
        public Patient Patient { get; set; }

        [Key, ForeignKey("Patient"), Column(Order = 1)]
        public string PatientPesel { get; set; }

        public Diagnose Diagnose { get; set; }

        [Key, ForeignKey("Diagnose"), Column(Order = 2)]
        public string DiagnoseId { get; set; }

        [Key, Column(Order = 3)]
        public DateTime Date { get; set; }

        public string Comment { get; set; }
    }
}