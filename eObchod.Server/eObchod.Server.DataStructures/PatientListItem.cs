using eObchod.Server.Database.Entities;

namespace eObchod.Server.DataStructures
{
    public class PatientListItem
    {
        public string Pesel { get; set; }
        public string Name { get; set; }

        public static explicit operator PatientListItem(Patient patient)
        {
            return new PatientListItem
            {
                Name = patient.FirstName + " " + patient.LastName,
                Pesel = patient.Pesel
            };
        }
    }
}
