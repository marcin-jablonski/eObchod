using eObchod.Server.Database.Entities;

namespace eObchod.Server.API.Models
{
    public class PatientBindingModel
    {
        public int PatientId;
        public string FirstName;
        public string LastName;
        public int Age;
        public int WardId;
        public int BlockId;

        public static explicit operator Patient(PatientBindingModel model)
        {
            return new Patient
            {
                PatientId = model.PatientId,
                Age = model.Age,
                BlockId = model.BlockId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                WardId = model.WardId
            };
        }
    }
}