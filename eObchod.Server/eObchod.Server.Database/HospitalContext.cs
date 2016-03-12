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

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
    }
}
