using System.Collections.Generic;
using System.Linq;
using eObchod.Server.Database;
using eObchod.Server.DataStructures;

namespace eObchod.Server.Logic.Interactions
{
    public class RoomManager : IRoomManager
    {
        public List<RoomListItem> GetRooms(int blockId, int wardId)
        {
            List<RoomListItem> rooms;
            using (var ctx = new HospitalContext())
            {
                rooms = ctx.Rooms.Where(r => r.BlockId == blockId && r.WardId == wardId).Cast<RoomListItem>().ToList();
            }
            return rooms;
        }
    }
}