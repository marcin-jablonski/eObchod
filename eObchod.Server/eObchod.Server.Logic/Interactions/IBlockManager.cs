using System.Collections.Generic;
using eObchod.Server.DataStructures;

namespace eObchod.Server.Logic.Interactions
{
    public interface IBlockManager
    {
        List<BlockListItem> GetBlocks();
    }
}