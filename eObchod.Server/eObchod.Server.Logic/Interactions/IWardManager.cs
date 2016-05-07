using System.Collections.Generic;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.Logic.Interactions
{
    public interface IWardManager
    {
        List<Ward> GetWards(int blockId);
    }
}