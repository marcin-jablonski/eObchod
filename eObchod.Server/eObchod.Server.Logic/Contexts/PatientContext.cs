using System.Collections.Generic;
using eObchod.Server.Database.Entities;
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

        public List<Patient> GetPatients(int blockId, int wardId, int roomId)
        {
            return _patientsManager.GetPatients(blockId, wardId, roomId);
        }

        public Patient GetPatient(string pesel)
        {
            return _patientsManager.GetPatient(pesel);
        }

        public string AddPatient(Patient patient)
        {
            return _patientsManager.AddPatient(patient);
        }
    }
}