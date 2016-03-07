using System;
using eObchod.Server.Database.Entities;

namespace eObchod.Server.API.Models
{
    public class PatientBindingModel
    {
        //to fill later

        public static explicit operator Patient(PatientBindingModel model)
        {
            return new Patient();
        }
    }
}