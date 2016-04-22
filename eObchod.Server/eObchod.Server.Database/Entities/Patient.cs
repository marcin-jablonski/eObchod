using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eObchod.Server.Database.Entities
{
    public class Patient
    {
        [Key]
        public string Pesel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string MainBookNumber { get; set; }
        public bool IsAdmitted { get; set; }
        public List<WardBookNumberItem> WardBookNumbers { get; set; }
        public List<Admittance> Admittances { get; set; }
        public List<DiagnoseHistoryItem> Diagnoses { get; set; }
        public List<MedicineHistoryItem> Medicines { get; set; }
        public List<ProcedureHistoryItem> Procedures { get; set; } 
    }

    public enum Gender { Unknown = 0, Male = 1, Female = 2, NA = 9}
}
