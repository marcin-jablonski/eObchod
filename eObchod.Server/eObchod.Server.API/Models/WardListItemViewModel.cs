using eObchod.Server.DataStructures;

namespace eObchod.Server.API.Models
{
    public class WardListItemViewModel
    {
        public string Name { get; set; }
        public int BlockId { get; set; }
        public int Id { get; set; }

        public static explicit operator WardListItemViewModel(WardListItem wli)
        {
            return new WardListItemViewModel
            {
                Name = wli.Name,
                BlockId = wli.BlockId,
                Id = wli.Id
            };
        }
    }
}