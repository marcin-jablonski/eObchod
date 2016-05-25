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

        public List<Patient> GetPatients(int blockId, int wardId, int roomId)
        {
            List<Patient> patientListItems;
            using (var ctx = new HospitalContext())
            {
                var patients =
                    ctx.Patients.Where(
                        patient =>
                            patient.BlockId == blockId && patient.WardId == wardId && patient.RoomId == roomId &&
                            patient.IsAdmitted);
                patientListItems = patients.ToList();
            }
            return patientListItems;
        }

        public List<Patient> GetPatients()
        {
            List<Patient> patientListItems;
            using (var ctx = new HospitalContext())
            {
                var patients =
                    ctx.Patients;
                patientListItems = patients.ToList();
            }
            return patientListItems;
        }

        public PatientModel GetPatient(string pesel)
        {
            PatientModel patient;
            using (var ctx = new HospitalContext())
            {
                var patientEntity =
                    ctx.Patients.Include(p => p.Admittances)
                        .Include(p => p.Diagnoses)
                        .Include(p => p.Medicines)
                        .Include(p => p.Procedures)
                        .Include(p => p.WardBookNumbers)
                        .FirstOrDefault(p => p.Pesel == pesel);

                foreach (var med in patientEntity.Medicines)
                {
                    med.Medicine = ctx.Medicines.FirstOrDefault(x => x.ATC == med.ATC);
                }

                foreach (var diag in patientEntity.Diagnoses)
                {
                    diag.Diagnose = ctx.Diagnoses.FirstOrDefault(x => x.DiagnoseId == diag.DiagnoseId);
                }

                foreach (var proc in patientEntity.Procedures)
                {
                    proc.Procedure = ctx.Procedures.FirstOrDefault(x => x.ProcedureId == proc.ProcedureId);
                }

                patient = (PatientModel) patientEntity;
            }
            return patient;
        }
    }
}
