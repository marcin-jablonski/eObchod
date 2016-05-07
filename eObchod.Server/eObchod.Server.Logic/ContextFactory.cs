using eObchod.Server.Logic.Contexts;
using eObchod.Server.Logic.Interactions;

namespace eObchod.Server.Logic
{
    public class ContextFactory
    {
        private static IPatientContext _patientContext;
        private static IHospitalStructureContext _hospitalStructureContext;

        static ContextFactory()
        {
            _patientContext = new PatientContext(new PatientsManager());
            _hospitalStructureContext = new HospitalStructureContext(new BlockManager(), new WardManager(), new RoomManager());
        }

        public static IPatientContext GetPatientContext()
        {
            return _patientContext;
        }

        public static IHospitalStructureContext GetHospitalStructureContext()
        {
            return _hospitalStructureContext;
        }
    }
}