using System.Collections.Generic;
using System.Linq;
using eObchod.Server.Database.Entities;
using eObchod.Server.DataStructures;

namespace eObchod.Server.API.Models
{
    public class ProcedureHistoryItemViewModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
        public Dictionary<string, string> Parameters { get; set; } 

        public static explicit operator ProcedureHistoryItemViewModel(ProcedureHistoryItemModel phi)
        {
            return new ProcedureHistoryItemViewModel
            {
                Name = phi.Procedure,
                Comment = phi.Comment,
                Date = phi.Date.ToShortDateString(),
                Parameters = phi.Parameters
            };
        }
    }
}