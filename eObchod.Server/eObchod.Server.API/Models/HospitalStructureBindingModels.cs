using eObchod.Server.Database.Entities;

namespace eObchod.Server.API.Models
{
    public class BlockBindingModel
    {
        public int BlockId { get; set; }
        public string Name { get; set; }

        public static explicit operator Block(BlockBindingModel model)
        {
            return new Block
            {
                BlockId = model.BlockId,
                Name = model.Name
            };
        }
    }
}