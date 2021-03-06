﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual List<WardBookNumberItem> WardBookNumbers { get; set; }
        public virtual List<Admittance> Admittances { get; set; }
        public virtual List<DiagnoseHistoryItem> Diagnoses { get; set; }
        public virtual List<MedicineHistoryItem> Medicines { get; set; }
        public virtual List<ProcedureHistoryItem> Procedures { get; set; }
        public Room Room { get; set; }
        [ForeignKey("Room"), Column(Order = 3)]
        public int RoomId { get; set; }
        [ForeignKey("Room"), Column(Order = 2)]
        public int WardId { get; set; }
        [ForeignKey("Room"), Column(Order = 1)]
        public int BlockId { get; set; }
    }

    public enum Gender { Unknown = 0, Male = 1, Female = 2, NA = 9}
}
