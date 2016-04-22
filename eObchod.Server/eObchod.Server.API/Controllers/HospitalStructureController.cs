using System.Web.Http;
using eObchod.Server.API.Models;
using eObchod.Server.Database.Entities;
using eObchod.Server.Logic;

namespace eObchod.Server.API.Controllers
{
    [Route("api/HospitalStructure")]
    public class HospitalStructureController : ApiController
    {
        [Route("api/HospitalStructure/AddBlock")]
        [HttpPost]
        public object AddBlock([FromBody] BlockBindingModel model)
        {
            HospitalStructureManager.AddBlock((Block) model);
            return Ok();
        }
    }
}
