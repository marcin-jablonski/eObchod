using System;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.DataStructures
{
    public class MedicineHistoryItemModel
    {
        public string PatientPesel { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Medicine { get; set; }

        public string Note { get; set; }

        public static explicit operator MedicineHistoryItemModel(MedicineHistoryItem model)
        {
            return new MedicineHistoryItemModel
            {
                EndDate = model.EndDate,
                Medicine = model.Medicine.Name,
                Note = model.Note,
                PatientPesel = model.PatientPesel,
                StartDate = model.StartDate
            };
        }
    }
}