using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using eObchod.Server.API.Models;
using eObchod.Server.Logic;

namespace eObchod.Server.API.Controllers
{
    [RoutePrefix("api/HospitalStructure")]
    public class HospitalStructureController : ApiController
    {
        [HttpGet]
        [Route("Blocks")]
        public List<BlockListItemViewModel> Blocks()
        {
            return ContextFactory.GetHospitalStructureContext().GetBlocks().Select(x => (BlockListItemViewModel) x).ToList();
        }

        [HttpGet]
        [Route("Wards")]
        public List<WardListItemViewModel> Wards([FromUri] int blockId)
        {
            return ContextFactory.GetHospitalStructureContext().GetWards(blockId).Select(x => (WardListItemViewModel) x).ToList();
        }

        [HttpGet]
        [Route("Rooms")]
        public List<RoomListItemViewModel> Rooms([FromUri] int blockId, [FromUri] int wardId)
        {
            return
                ContextFactory.GetHospitalStructureContext()
                    .GetRooms(blockId, wardId)
                    .Select(x => (RoomListItemViewModel) x)
                    .ToList();
        }
    }
}
