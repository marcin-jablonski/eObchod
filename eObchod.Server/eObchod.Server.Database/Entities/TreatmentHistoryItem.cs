using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eObchod.Server.Database.Entities
{
    public class TreatmentHistoryItem
    {
        public int Id { get; set; }
        public Treatment Treatment { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string, string> MeasuredParameters { get; set; }
        public string Comment { get; set; }
    }
}
