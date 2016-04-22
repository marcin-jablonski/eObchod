using System.Collections.Generic;
using System.Linq;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.API.Models
{
    public class BlockViewModel
    {
        public int BlockId { get; set; }
        public string Name { get; set; }
        public Dictionary<int, string> Wards { get; set; }

        public static explicit operator BlockViewModel(Block block)
        {
            return new BlockViewModel
            {
                BlockId = block.BlockId,
                Name = block.Name,
                Wards = block.Wards.ToDictionary(ward => ward.WardId, ward => ward.Name)
            };
        }
    }
}