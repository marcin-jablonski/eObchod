using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eObchod.Server.Database.Entities
{
    public class ProcedureHistoryItem
    {
        public Patient Patient { get; set; }

        [Key, ForeignKey("Patient"), Column(Order = 1)]
        public string PatientPesel { get; set; }

        public Procedure Procedure { get; set; }

        [Key, ForeignKey("Procedure"), Column(Order = 2)]
        public string ProcedureId { get; set; }

        [Key, Column(Order = 3)]
        public DateTime Date { get; set; }

        public virtual List<Parameter> Parameters { get; set; }

        public string Comment { get; set; }
    }
}
