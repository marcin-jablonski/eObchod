using System.Collections.Generic;
using eObchod.Server.Database.Entities;
using eObchod.Server.DataStructures;

namespace eObchod.Server.Logic.Contexts
{
    public interface IPatientContext
    {
        List<PatientListItem> GetPatients(int blockId, int wardId, int roomId);
        PatientModel GetPatient(string pesel);
        string AddPatient(Patient patient);
    }
}