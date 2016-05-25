using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using eObchod.Server.API.Models;
using eObchod.Server.DataStructures;
using eObchod.Server.Logic;

namespace eObchod.Server.API.Controllers
{
    [RoutePrefix("api/Patients")]
    public class PatientsController : ApiController
    {
        [HttpGet]
        public List<PatientListItemViewModel> Patients([FromUri] int blockId, [FromUri] int wardId, [FromUri] int roomId)
        {
            return
                ContextFactory.GetPatientContext()
                    .GetPatients(blockId, wardId, roomId)
                    .Select(x => (PatientListItemViewModel) x)
                    .ToList();
        }

        [HttpGet]
        public List<PatientListItemViewModel> Patients()
        {
            return
                ContextFactory.GetPatientContext()
                    .GetPatients()
                    .Select(x => (PatientListItemViewModel)x)
                    .ToList();
        }

        [HttpGet]
        public PatientViewModel Patient([FromUri] string pesel)
        {
            return (PatientViewModel) ContextFactory.GetPatientContext().GetPatient(pesel);
        }
    }
}
