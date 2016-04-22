using System.ComponentModel.DataAnnotations;

namespace eObchod.Server.Database.Entities
{
    public class Procedure
    {
        [Key]
        public string ProcedureId { get; set; }

        public string Description { get; set; }
    }
}
