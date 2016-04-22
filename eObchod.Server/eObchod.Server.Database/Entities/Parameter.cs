using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eObchod.Server.Database.Entities
{
    public class Parameter
    {
        [Key, Column(Order = 4)]
        public string Name { get; set; }

        [Key, Column(Order = 5)]
        public string Value { get; set; }

        public ProcedureHistoryItem ProcedureHistoryItem { get; set; }

        [Key, ForeignKey("ProcedureHistoryItem"), Column(Order = 1)]
        public string PatientPesel { get; set; }

        [Key, ForeignKey("ProcedureHistoryItem"), Column(Order = 2)]
        public string ProcedureId { get; set; }

        [Key, ForeignKey("ProcedureHistoryItem"), Column(Order = 3)]
        public DateTime Date { get; set; }
    }
}