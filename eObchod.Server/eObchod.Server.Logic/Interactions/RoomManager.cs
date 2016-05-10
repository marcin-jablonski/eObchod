using System.Collections.Generic;
using System.Linq;
using eObchod.Server.Database;
using eObchod.Server.Database.Entities;
using eObchod.Server.DataStructures;

namespace eObchod.Server.Logic.Interactions
{
    public class RoomManager : IRoomManager
    {
        public List<Room> GetRooms(int blockId, int wardId)
        {
            List<Room> rooms;
            using (var ctx = new HospitalContext())
            {
                rooms = ctx.Rooms.Where(r => r.BlockId == blockId && r.WardId == wardId).ToList();
            }
            return rooms;
        }
    }
}