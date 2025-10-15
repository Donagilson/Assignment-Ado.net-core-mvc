using PatientManagementSystem2025.Models;

namespace PatientManagementSystem2025.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(int? id);
        List<Membership> GetAllMemberships();
        void AddPatient(Patient patient);
        void EditAndUpdatePatient(Patient patient);
    }
}
