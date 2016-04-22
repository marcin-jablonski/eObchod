using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eObchod.Server.Database.Entities
{
    public class Room
    {
        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        public Ward Ward { get; set; }

        [Key, ForeignKey("Ward")]
        [Column(Order = 2)]
        public int WardId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Ward")]
        public int BlockId { get; set; }

        public string Name { get; set; }

        public List<Patient> Patients { get; set; } 
    }
}