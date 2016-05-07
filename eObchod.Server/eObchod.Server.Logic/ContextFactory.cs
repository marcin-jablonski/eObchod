using eObchod.Server.Logic.Contexts;
using eObchod.Server.Logic.Interactions;

namespace eObchod.Server.Logic
{
    public class ContextFactory
    {
        private static IPatientContext _patientContext;

        static ContextFactory()
        {
            _patientContext = new PatientContext(new PatientsManager());
        }

        public static IPatientContext GetPatientContext()
        {
            return _patientContext;
        }
    }
}