using System.Collections.Generic;
using System.Linq;
using eObchod.Server.Database;
using eObchod.Server.DataStructures;

namespace eObchod.Server.Logic.Interactions
{
    public class WardManager : IWardManager
    {
        public List<WardListItem> GetWards(int blockId)
        {
            List<WardListItem> wards;
            using (var ctx = new HospitalContext())
            {
                wards = ctx.Wards.Where(w => w.BlockId == blockId).Cast<WardListItem>().ToList();
            }
            return wards;
        }
    }
}