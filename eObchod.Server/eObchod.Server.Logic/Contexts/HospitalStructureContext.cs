using System.Collections.Generic;
using System.Linq;
using eObchod.Server.DataStructures;
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

        public List<BlockListItem> GetBlocks()
        {
            return _blockManager.GetBlocks().Select(x => (BlockListItem) x).ToList();
        }

        public List<WardListItem> GetWards(int blockId)
        {
            return _wardManager.GetWards(blockId).Select(x => (WardListItem) x).ToList();
        }

        public List<RoomListItem> GetRooms(int blockId, int wardId)
        {
            return _roomManager.GetRooms(blockId, wardId).Select(x => (RoomListItem) x).ToList();
        }
    }
}