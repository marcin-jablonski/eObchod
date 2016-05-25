using System;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.DataStructures
{
    public class DiagnoseHistoryItemModel
    {
        public string PatientPesel { get; set; }

        public string Diagnose { get; set; }

        public DateTime Date { get; set; }

        public string Comment { get; set; }

        public static explicit operator DiagnoseHistoryItemModel(DiagnoseHistoryItem model)
        {
            return new DiagnoseHistoryItemModel
            {
                Date = model.Date,
                Comment = model.Comment,
                Diagnose = model.Diagnose.Description,
                PatientPesel = model.PatientPesel
            };
        }
    }
}