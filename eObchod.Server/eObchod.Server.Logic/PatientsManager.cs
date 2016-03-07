using eObchod.Server.Database;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.Logic
{
    public class PatientsManager
    {
        public static void AddPatient(Patient patient)
        {
            using (var ctx = new HospitalContext())
            {
                ctx.Patients.Add(patient);
                ctx.SaveChanges();
            }
        }
    }
}
