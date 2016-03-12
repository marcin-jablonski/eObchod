using System;
using System.ComponentModel.DataAnnotations;

namespace eObchod.Server.Database.Entities
{
    public class Patient
    {
        [Key]
        public string Pesel { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public HospitalizationHistory HospitalizationHistory { get; set; }
    }

    public enum Gender { Unknown = 0, Male = 1, Female = 2, NA = 9}
}
