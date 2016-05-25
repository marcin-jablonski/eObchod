using System;
using System.Collections.Generic;
using System.Linq;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.DataStructures
{
    public class ProcedureHistoryItemModel
    {
        public string PatientPesel { get; set; }

        public string Procedure { get; set; }

        public DateTime Date { get; set; }

        public virtual Dictionary<string, string> Parameters { get; set; }

        public string Comment { get; set; }

        public static explicit operator ProcedureHistoryItemModel(ProcedureHistoryItem model)
        {
            return new ProcedureHistoryItemModel
            {
                Comment = model.Comment,
                Date = model.Date,
                Parameters = model.Parameters.ToDictionary(par => par.Name, par => par.Value),
                PatientPesel = model.PatientPesel,
                Procedure = model.Procedure.Description
            };
        }
    }
}