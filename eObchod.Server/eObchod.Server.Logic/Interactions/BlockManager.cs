using System.Collections.Generic;
using System.Linq;
using eObchod.Server.Database;
using eObchod.Server.DataStructures;

namespace eObchod.Server.Logic.Interactions
{
    public class BlockManager : IBlockManager
    {
        public List<BlockListItem> GetBlocks()
        {
            List<BlockListItem> blocks;
            using (var ctx = new HospitalContext())
            {
                blocks = ctx.Blocks.Select(x => (BlockListItem) x).ToList();
            }
            return blocks;
        }
    }
}