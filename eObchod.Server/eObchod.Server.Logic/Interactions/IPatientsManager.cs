using System.Collections.Generic;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.Logic.Interactions
{
    public interface IPatientsManager
    {
        string AddPatient(Patient patient);
        List<Patient> GetPatients(int blockId, int wardId, int roomId);
        Patient GetPatient(string pesel);
    }
}