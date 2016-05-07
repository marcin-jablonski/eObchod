using eObchod.Server.Database.Entities;

namespace eObchod.Server.DataStructures
{
    public class BlockListItem
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public static explicit operator BlockListItem(Block block)
        {
            return new BlockListItem
            {
                Id = block.BlockId,
                Name = block.Name
            };
        }
    }
}