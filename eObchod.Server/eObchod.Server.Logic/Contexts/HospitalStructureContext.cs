using System.Collections.Generic;
using eObchod.Server.Database.Entities;
using eObchod.Server.Logic.Interactions;

namespace eObchod.Server.Logic.Contexts
{
    public class HospitalStructureContext : IHospitalStructureContext
    {
        private IBlockManager _blockManager;
        private IWardManager _wardManager;
        private IRoomManager _roomManager;

        public HospitalStructureContext(IBlockManager blockManager, IWardManager wardManager, IRoomManager roomManager)
        {
            _blockManager = blockManager;
            _wardManager = wardManager;
            _roomManager = roomManager;
        }

        public List<Block> GetBlocks()
        {
            return _blockManager.GetBlocks();
        }

        public List<Ward> GetWards(int blockId)
        {
            return _wardManager.GetWards(blockId);
        }

        public List<Room> GetRooms(int blockId, int wardId)
        {
            return _roomManager.GetRooms(blockId, wardId);
        }
    }
}