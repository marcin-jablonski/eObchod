using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eObchod.Server.Database.Entities
{
    public class WardBookNumberItem
    {
        public Patient Patient { get; set; }

        [Key, ForeignKey("Patient"), Column(Order = 3)]
        public string PatientPesel { get; set; }

        public Ward Ward { get; set; }

        [Key, ForeignKey("Ward"), Column(Order = 2)]
        public int WardId { get; set; }

        [Key, ForeignKey("Ward"), Column(Order = 1)]
        public int BlockId { get; set; }

        public string WardBookNumber { get; set; }
    }
}