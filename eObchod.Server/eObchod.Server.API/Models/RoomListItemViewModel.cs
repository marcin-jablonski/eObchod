using eObchod.Server.DataStructures;

namespace eObchod.Server.API.Models
{
    public class RoomListItemViewModel
    {
        public string Name { get; set; }
        public int BlockId { get; set; }
        public int WardId { get; set; }
        public int Id { get; set; }

        public static explicit operator RoomListItemViewModel(RoomListItem rli)
        {
            return new RoomListItemViewModel
            {
                BlockId = rli.BlockId,
                Id = rli.Id,
                Name = rli.Name,
                WardId = rli.WardId
            };
        }
    }
}