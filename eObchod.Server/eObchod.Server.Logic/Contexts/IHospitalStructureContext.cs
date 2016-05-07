using System.Collections.Generic;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.Logic.Contexts
{
    public interface IHospitalStructureContext
    {
        List<Block> GetBlocks();
        List<Ward> GetWards(int blockId);
        List<Room> GetRooms(int blockId, int wardId);
    }
}