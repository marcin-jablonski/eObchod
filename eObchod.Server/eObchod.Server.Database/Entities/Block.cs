using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eObchod.Server.Database.Entities
{
    public class Block
    {
        [Key]
        public int BlockId { get; set; }

        public string Name { get; set; }

        public virtual List<Ward> Wards { get; set; } 
    }
}