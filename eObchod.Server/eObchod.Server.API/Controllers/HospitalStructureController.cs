using System.Web.Http;
using eObchod.Server.API.Models;
using eObchod.Server.Database.Entities;
using eObchod.Server.Logic;

namespace eObchod.Server.API.Controllers
{
    [Route("api/HospitalStructure")]
    public class HospitalStructureController : ApiController
    {
        [Route("api/HospitalStructure/Block")]
        [HttpPost]
        public object AddBlock([FromBody] BlockBindingModel model)
        {
            HospitalStructureManager.AddBlock((Block) model);
            return Ok();
        }

        [Route("api/HospitalStructure/Ward")]
        [HttpPost]
        public object AddWard([FromBody] WardBindingModel model)
        {
            HospitalStructureManager.AddWard((Ward) model);
            return Ok();
        }

        [Route("api/HospitalStructure/Block/{id}")]
        [HttpGet]
        public BlockViewModel GetBlock(int id)
        {
            return (BlockViewModel) HospitalStructureManager.GetBlock(id);
        }
    }
}
