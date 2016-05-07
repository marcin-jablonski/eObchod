using System.Collections.Generic;
using eObchod.Server.DataStructures;

namespace eObchod.Server.Logic.Interactions
{
    public interface IRoomManager
    {
        List<RoomListItem> GetRooms(int blockId, int wardId);
    }
}