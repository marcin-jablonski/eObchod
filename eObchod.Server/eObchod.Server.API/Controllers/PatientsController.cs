using System.Web.Http;
using eObchod.Server.API.Models;
using eObchod.Server.Database.Entities;
using eObchod.Server.Logic;

namespace eObchod.Server.API.Controllers
{
    [Route("api/Patients")]
    public class PatientsController : ApiController
    {
        [HttpPost]
        public object AddPatient([FromBody] PatientBindingModel patient)
        {
            PatientsManager.AddPatient((Patient) patient);
            return Ok();
        }
    }
}
