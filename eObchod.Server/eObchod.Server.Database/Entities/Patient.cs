namespace eObchod.Server.Database.Entities
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int WardId { get; set; }
        public int BlockId { get; set; }
    }
}
