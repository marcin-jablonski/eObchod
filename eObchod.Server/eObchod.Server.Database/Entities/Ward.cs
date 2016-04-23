using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eObchod.Server.Database.Entities
{
    public class Ward
    {
        [Key, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WardId { get; set; }

        public Block Block { get; set; }

        [Key, ForeignKey("Block"), Column(Order = 1)]
        public int BlockId { get; set; }

        public string Name { get; set; }

        public virtual List<Room> Rooms { get; set; }
    }
}