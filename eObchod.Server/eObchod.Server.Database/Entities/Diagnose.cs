﻿using System.ComponentModel.DataAnnotations;

namespace eObchod.Server.Database.Entities
{
    public class Diagnose
    {
        [Key]
        public string DiagnoseId { get; set; }

        public string Description { get; set; }
    }
}
