using eObchod.Server.Database.Entities;

namespace eObchod.Server.DataStructures
{
    public class WardListItem
    {
        public string Name { get; set; }
        public int BlockId { get; set; }
        public int Id { get; set; }

        public static explicit operator WardListItem(Ward ward)
        {
            return new WardListItem
            {
                BlockId = ward.BlockId,
                Id = ward.WardId,
                Name = ward.Name
            };
        }
    }
}