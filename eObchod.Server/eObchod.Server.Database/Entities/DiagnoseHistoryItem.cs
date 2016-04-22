using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eObchod.Server.Database.Entities
{
    public class DiagnoseHistoryItem
    {
        [ForeignKey("PatientPesel")]
        public Patient Patient { get; set; }

        [Key]
        [Column(Order = 1)]
        public string PatientPesel { get; set; }

        [ForeignKey("DiagnoseId")]
        public Diagnose Diagnose { get; set; }

        [Key]
        [Column(Order = 2)]
        public string DiagnoseId { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime Date { get; set; }

        public string Comment { get; set; }
    }
}