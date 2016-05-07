using System.Collections.Generic;
using eObchod.Server.Database.Entities;
using eObchod.Server.DataStructures;

namespace eObchod.Server.Logic.Interactions
{
    public interface IPatientsManager
    {
        string AddPatient(Patient patient);
        List<PatientListItem> GetPatients(int blockId, int wardId, int roomId);
        Patient GetPatient(string pesel);
    }
}