using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eObchod.Server.Database.Entities
{
    public class WardBookNumberItem
    {
        [ForeignKey("PatientPesel")]
        public Patient Patient { get; set; }

        [Key]
        [Column(Order = 1)]
        public string PatientPesel { get; set; }

        [ForeignKey("WardId")]
        public Ward Ward { get; set; }

        [Key]
        [Column(Order = 2)]
        public int WardId { get; set; }

        public string WardBookNumber { get; set; }
    }
}