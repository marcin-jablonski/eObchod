using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eObchod.Server.Database.Entities
{
    public class HospitalizationHistory
    {
        public int Id { get; set; }
        public string MainBookId { get; set; }
        public Dictionary<int, string> WardBookIds { get; set; }
        public bool IsAdmitted { get; set; }
        public int WardId { get; set; }
        public int BlockId { get; set; }
        public DateTime AdmittanceDate { get; set; }
        public List<AdmittanceData> AdmittanceHistory { get; set; }
        public List<TreatmentHistoryItem> TreatmentHistory { get; set; } 
    }
}
