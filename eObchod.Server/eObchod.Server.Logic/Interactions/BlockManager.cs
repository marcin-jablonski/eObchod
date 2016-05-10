using System.Collections.Generic;
using System.Linq;
using eObchod.Server.Database;
using eObchod.Server.Database.Entities;
using eObchod.Server.DataStructures;

namespace eObchod.Server.Logic.Interactions
{
    public class BlockManager : IBlockManager
    {
        public List<Block> GetBlocks()
        {
            List<Block> blocks;
            using (var ctx = new HospitalContext())
            {
                blocks = ctx.Blocks.ToList();
            }
            return blocks;
        }
    }
}