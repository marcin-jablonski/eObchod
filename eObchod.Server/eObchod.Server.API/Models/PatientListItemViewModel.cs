using eObchod.Server.DataStructures;

namespace eObchod.Server.API.Models
{
    public class PatientListItemViewModel
    {
        public string Name { get; set; }
        public string Pesel { get; set; }

        public static explicit operator PatientListItemViewModel(PatientListItem pli)
        {
            return new PatientListItemViewModel
            {
                Name = pli.Name,
                Pesel = pli.Pesel
            };
        }
    }
}