using System.Data.Entity;
using System.Linq;
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

        public static void AddWard(Ward ward)
        {
            using (var ctx = new HospitalContext())
            {
                ctx.Wards.Add(ward);
                ctx.SaveChanges();
            }
        }

        public static Block GetBlock(int blockId)
        {
            using (var ctx = new HospitalContext())
            {
                return ctx.Blocks.Include(b => b.Wards).FirstOrDefault(b => b.BlockId == blockId);
            }
        }
    }
}