using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using eObchod.Server.Database;
using eObchod.Server.Database.Entities;
using eObchod.Server.DataStructures;

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

        public List<PatientListItem> GetPatients(int blockId, int wardId, int roomId)
        {
            var patientListItems = new List<PatientListItem>();
            using (var ctx = new HospitalContext())
            {
                var patients =
                    ctx.Patients.Where(
                        patient =>
                            patient.BlockId == blockId && patient.WardId == wardId && patient.RoomId == roomId &&
                            patient.IsAdmitted);
                patientListItems = patients.Cast<PatientListItem>().ToList();
            }
            return patientListItems;
        }

        public Patient GetPatient(string pesel)
        {
            Patient patient;
            using (var ctx = new HospitalContext())
            {
                patient =
                    ctx.Patients.Include(p => p.Admittances)
                        .Include(p => p.Diagnoses)
                        .Include(p => p.Medicines)
                        .Include(p => p.Procedures)
                        .Include(p => p.WardBookNumbers)
                        .FirstOrDefault(p => p.Pesel == pesel);
            }
            return patient;
        }
    }
}
