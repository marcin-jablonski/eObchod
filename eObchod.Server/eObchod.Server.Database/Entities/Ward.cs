using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eObchod.Server.Database.Entities
{
    public class Ward
    {
        [Key]
        [Column(Order = 2)]
        public int WardId { get; set; }

        [ForeignKey("BlockId")]
        public Block Block { get; set; }

        [Key]
        [Column(Order = 1)]
        public int BlockId { get; set; }

        public string Name { get; set; }

        public List<Room> Rooms { get; set; }
    }
}