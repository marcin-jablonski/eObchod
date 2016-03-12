using System.ComponentModel.DataAnnotations;

namespace eObchod.Server.Database.Entities
{
    public class Medicine
    {
        [Key]
        public string ATC { get; set; }
        public string Name { get; set; }
        public float DDD { get; set; }
        public Unit Unit { get; set; }
        public AdministrationRoute AdministrationRoute { get; set; }
        public string Note { get; set; }
    }

    public enum Unit { g, mg, mcg, U, TU, MU, mmol, ml }

    public enum AdministrationRoute { Implant, Inhal, N, Instill, O, P, R, SL, TD, V }
}
