using System.Data.Entity;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.Database
{
    public class HospitalContext : DbContext
    {
        public HospitalContext() : base("eObchod")
        {
            System.Data.Entity.Database.SetInitializer(new CreateDatabaseIfNotExists<HospitalContext>());
        }

        public DbSet<Admittance> Admittances { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<DiagnoseHistoryItem> DiagnoseHistoryItems { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineHistoryItem> MedicineHistoryItems { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Procedure> Procedures { get; set; }
        public DbSet<ProcedureHistoryItem> ProcedureHistoryItems { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<WardBookNumberItem> WardBookNumberItems { get; set; }
    }
}
