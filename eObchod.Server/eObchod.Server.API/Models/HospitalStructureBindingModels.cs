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

    public class WardBindingModel
    {
        public int WardId { get; set; }
        public int BlockId { get; set; }
        public string Name { get; set; }

        public static explicit operator Ward(WardBindingModel model)
        {
            return new Ward
            {
                BlockId = model.BlockId,
                WardId = model.WardId,
                Name = model.Name
            };
        }
    }
}