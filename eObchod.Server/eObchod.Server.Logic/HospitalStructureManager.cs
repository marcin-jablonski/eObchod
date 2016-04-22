using eObchod.Server.Database;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.Logic
{
    public class HospitalStructureManager
    {
        public static void AddBlock(Block block)
        {
            using (var ctx = new HospitalContext())
            {
                ctx.Blocks.Add(block);
                ctx.SaveChanges();
            }
        }
    }
}