using System;

namespace eObchod.Server.Database.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Gender { get; set; }
        public int WardId { get; set; }
        public int BlockId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime AdmittanceDate { get; set; }
        public DateTime DischargeDate { get; set; }
    }
}
