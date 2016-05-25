using eObchod.Server.Database.Entities;
using eObchod.Server.DataStructures;

namespace eObchod.Server.API.Models
{
    public class DiagnoseHistoryItemViewModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }

        public static explicit operator DiagnoseHistoryItemViewModel(DiagnoseHistoryItemModel dhi)
        {
            return new DiagnoseHistoryItemViewModel
            {
                Name = dhi.Diagnose,
                Date = dhi.Date.ToShortDateString(),
                Comment = dhi.Comment
            };
        }
    }
}