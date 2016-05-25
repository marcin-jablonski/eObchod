using System;
using eObchod.Server.Database.Entities;
using eObchod.Server.DataStructures;

namespace eObchod.Server.API.Models
{
    public class MedicineHistoryItemViewModel
    {
        public string Name { get; set; }
        public string FromTo { get; set; }
        public string Note { get; set; }

        public static explicit operator MedicineHistoryItemViewModel(MedicineHistoryItemModel mhi)
        {
            return new MedicineHistoryItemViewModel
            {
                Name = mhi.Medicine,
                FromTo = mhi.StartDate.ToShortDateString() + (mhi.EndDate != null ? " - " + ((DateTime) mhi.EndDate).ToShortDateString() : ""),
                Note = mhi.Note
            };
        }
    }
}