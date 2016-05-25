using System.Collections.Generic;
using System.Linq;
using eObchod.Server.Database.Entities;
using eObchod.Server.DataStructures;
using eObchod.Server.Logic.Interactions;

namespace eObchod.Server.Logic.Contexts
{
    public class PatientContext : IPatientContext
    {
        private IPatientsManager _patientsManager;

        public PatientContext(IPatientsManager patientsManager)
        {
            _patientsManager = patientsManager;
        }

        public List<PatientListItem> GetPatients(int blockId, int wardId, int roomId)
        {
            return _patientsManager.GetPatients(blockId, wardId, roomId).Select(x => (PatientListItem) x).ToList();
        }

        public PatientModel GetPatient(string pesel)
        {
            return _patientsManager.GetPatient(pesel);
        }

        public string AddPatient(Patient patient)
        {
            return _patientsManager.AddPatient(patient);
        }
    }
}