using System.Collections.Generic;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.Logic.Contexts
{
    public interface IPatientContext
    {
        List<Patient> GetPatients(int blockId, int wardId, int roomId);
        Patient GetPatient(string pesel);
        string AddPatient(Patient patient);
    }
}