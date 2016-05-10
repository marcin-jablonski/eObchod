using System.Collections.Generic;
using eObchod.Server.Database.Entities;
using eObchod.Server.DataStructures;

namespace eObchod.Server.Logic.Interactions
{
    public interface IRoomManager
    {
        List<Room> GetRooms(int blockId, int wardId);
    }
}