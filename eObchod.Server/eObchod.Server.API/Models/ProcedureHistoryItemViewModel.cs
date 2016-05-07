using System.Collections.Generic;
using System.Linq;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.API.Models
{
    public class ProcedureHistoryItemViewModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
        public Dictionary<string, string> Parameters { get; set; } 

        public static explicit operator ProcedureHistoryItemViewModel(ProcedureHistoryItem phi)
        {
            return new ProcedureHistoryItemViewModel
            {
                Name = phi.Procedure.Description,
                Comment = phi.Comment,
                Date = phi.Date.ToShortDateString(),
                Parameters = phi.Parameters.ToDictionary(par => par.Name, par => par.Value)
            };
        }
    }
}