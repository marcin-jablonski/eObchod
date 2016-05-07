using eObchod.Server.Database.Entities;

namespace eObchod.Server.DataStructures
{
    public class RoomListItem
    {
        public string Name { get; set; }
        public int BlockId { get; set; }
        public int WardId { get; set; }
        public int Id { get; set; }

        public static explicit operator RoomListItem(Room room)
        {
            return new RoomListItem
            {
                BlockId = room.BlockId,
                Id = room.RoomId,
                Name = room.Name,
                WardId = room.WardId
            };
        }
    }
}