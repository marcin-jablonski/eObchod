using System;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.API.Models
{
    public class MedicineHistoryItemViewModel
    {
        public string Name { get; set; }
        public string FromTo { get; set; }
        public string Note { get; set; }

        public static explicit operator MedicineHistoryItemViewModel(MedicineHistoryItem mhi)
        {
            return new MedicineHistoryItemViewModel
            {
                Name = mhi.Medicine.Name,
                FromTo = mhi.StartDate.ToShortDateString() + (mhi.EndDate != null ? " - " + ((DateTime) mhi.EndDate).ToShortDateString() : ""),
                Note = mhi.Note
            };
        }
    }
}