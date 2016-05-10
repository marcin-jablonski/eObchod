using System.Collections.Generic;
using System.Linq;
using eObchod.Server.Database;
using eObchod.Server.Database.Entities;
using eObchod.Server.DataStructures;

namespace eObchod.Server.Logic.Interactions
{
    public class WardManager : IWardManager
    {
        public List<Ward> GetWards(int blockId)
        {
            List<Ward> wards;
            using (var ctx = new HospitalContext())
            {
                wards = ctx.Wards.Where(w => w.BlockId == blockId).ToList();
            }
            return wards;
        }
    }
}