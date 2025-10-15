using PatientManagementSystem2025.Models;

namespace PatientManagementSystem2025.Repository
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> SelectAllPatients();
        Patient SelectPatientById(int? id);
        List<Membership> SelectAllMemberships();
        void InsertPatient(Patient patient);
        void UpdatePatient(Patient patient);
    }
}
