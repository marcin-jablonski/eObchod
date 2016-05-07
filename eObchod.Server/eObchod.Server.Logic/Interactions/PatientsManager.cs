using System.Collections.Generic;
using eObchod.Server.Database;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.Logic.Interactions
{
    public class PatientsManager : IPatientsManager
    {
        public string AddPatient(Patient patient)
        {
            using (var ctx = new HospitalContext())
            {
                ctx.Patients.Add(patient);
                ctx.SaveChanges();
            }
            return patient.Pesel;
        }

        public List<Patient> GetPatients(int blockId, int wardId, int roomId)
        {
            throw new System.NotImplementedException();
        }

        public Patient GetPatient(string pesel)
        {
            throw new System.NotImplementedException();
        }
    }
}
