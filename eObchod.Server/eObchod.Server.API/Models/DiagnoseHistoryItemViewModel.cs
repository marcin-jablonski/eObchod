using eObchod.Server.Database.Entities;

namespace eObchod.Server.API.Models
{
    public class DiagnoseHistoryItemViewModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }

        public static explicit operator DiagnoseHistoryItemViewModel(DiagnoseHistoryItem dhi)
        {
            return new DiagnoseHistoryItemViewModel
            {
                Name = dhi.Diagnose.Description,
                Date = dhi.Date.ToShortDateString(),
                Comment = dhi.Comment
            };
        }
    }
}