using eObchod.Server.DataStructures;

namespace eObchod.Server.API.Models
{
    public class BlockListItemViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public static explicit operator BlockListItemViewModel(BlockListItem bli)
        {
            return new BlockListItemViewModel
            {
                Id = bli.Id,
                Name = bli.Name
            };
        }
    }
}