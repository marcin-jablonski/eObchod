using System;
using System.Collections.Generic;
using System.Linq;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.DataStructures
{
    public class PatientModel
    {
        public string Pesel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string MainBookNumber { get; set; }
        public bool IsAdmitted { get; set; }
        public string WardBookNumber { get; set; }
        public List<DiagnoseHistoryItemModel> Diagnoses { get; set; }
        public List<MedicineHistoryItemModel> Medicines { get; set; }
        public List<ProcedureHistoryItemModel> Procedures { get; set; }
        public int RoomId { get; set; }
        public int WardId { get; set; }
        public int BlockId { get; set; }

        public static explicit operator PatientModel(Patient model)
        {
            return new PatientModel
            {
                BirthDate = model.BirthDate,
                BlockId = model.BlockId,
                Diagnoses = model.Diagnoses.Select(x => (DiagnoseHistoryItemModel) x).ToList(),
                FirstName = model.FirstName,
                Gender =
                    model.Gender == Database.Entities.Gender.Unknown
                        ? "Unknown"
                        : model.Gender == Database.Entities.Gender.NA
                            ? "NA"
                            : model.Gender == Database.Entities.Gender.Female ? "Female" : "Male",
                IsAdmitted = model.IsAdmitted,
                LastName = model.LastName,
                MainBookNumber = model.MainBookNumber,
                Medicines = model.Medicines.Select(x => (MedicineHistoryItemModel) x).ToList(),
                Pesel = model.Pesel,
                WardId = model.WardId,
                Procedures = model.Procedures.Select(x => (ProcedureHistoryItemModel) x).ToList(),
                RoomId = model.RoomId,
                WardBookNumber =
                    model.WardBookNumbers.FirstOrDefault(
                        wbn => wbn.WardId == model.Admittances.FirstOrDefault(admittance => admittance.Current).WardId)
                        .WardBookNumber
            };
        }
    }
}