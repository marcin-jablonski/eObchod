using System;
using System.Collections.Generic;
using System.Linq;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.API.Models
{
    public class PatientViewModel
    {
        public string Pesel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public int Age { get; set; }
        public string MainBookNumber { get; set; }
        public string WardBookNumber { get; set; }
        public List<MedicineHistoryItemViewModel> MedicineHistory { get; set; }
        public List<ProcedureHistoryItemViewModel> ProcedureHistory { get; set; }
        public List<DiagnoseHistoryItemViewModel> DiagnoseHistory { get; set; } 

        public static explicit operator PatientViewModel(Patient patient)
        {
            return new PatientViewModel
            {
                Pesel = patient.Pesel,
                Age = (DateTime.Now - patient.BirthDate).Days/365,
                BirthDate = patient.BirthDate.ToShortDateString(),
                FirstName = patient.FirstName,
                Gender =
                    patient.Gender == Database.Entities.Gender.Unknown
                        ? "Unknown"
                        : patient.Gender == Database.Entities.Gender.NA
                            ? "NA"
                            : patient.Gender == Database.Entities.Gender.Female ? "Female" : "Male",
                LastName = patient.LastName,
                MainBookNumber = patient.MainBookNumber,
                WardBookNumber =
                    patient.WardBookNumbers.FirstOrDefault(
                        wbn => wbn.WardId == patient.Admittances.FirstOrDefault(admittance => admittance.Current).WardId)
                        .WardBookNumber,
                DiagnoseHistory = patient.Diagnoses.Select(x => (DiagnoseHistoryItemViewModel) x).ToList(),
                ProcedureHistory = patient.Procedures.Select(x => (ProcedureHistoryItemViewModel) x).ToList(),
                MedicineHistory = patient.Medicines.Select(x => (MedicineHistoryItemViewModel) x).ToList()
            };
        }
    }
}