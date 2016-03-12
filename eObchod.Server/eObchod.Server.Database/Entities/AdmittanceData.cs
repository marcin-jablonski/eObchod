using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eObchod.Server.Database.Entities
{
    public class AdmittanceData
    {
        public int Id { get; set; }
        public int WardId { get; set; }
        public int BlockId { get; set; }
        public DateTime AdmittanceDate { get; set; }
        public DateTime DischargeDate { get; set; }
    }
}
