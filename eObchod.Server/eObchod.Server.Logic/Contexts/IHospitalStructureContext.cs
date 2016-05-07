using System.Collections.Generic;
using eObchod.Server.DataStructures;

namespace eObchod.Server.Logic.Contexts
{
    public interface IHospitalStructureContext
    {
        List<BlockListItem> GetBlocks();
        List<WardListItem> GetWards(int blockId);
        List<RoomListItem> GetRooms(int blockId, int wardId);
    }
}