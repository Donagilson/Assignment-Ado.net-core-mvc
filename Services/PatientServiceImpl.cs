using PatientManagementSystem2025.Models;
using PatientManagementSystem2025.Repository;

namespace PatientManagementSystem2025.Services
{
    public class PatientServiceImpl : IPatientService
    {
        private readonly IPatientRepository patientRepository;
        public PatientServiceImpl(IPatientRepository repository)
        {
            patientRepository = repository;
        }

        public IEnumerable<Patient> GetAllPatients() => patientRepository.SelectAllPatients();
        public Patient GetPatientById(int? id) => patientRepository.SelectPatientById(id);
        public List<Membership> GetAllMemberships() => patientRepository.SelectAllMemberships();
        public void AddPatient(Patient patient) => patientRepository.InsertPatient(patient);
        public void EditAndUpdatePatient(Patient patient) => patientRepository.UpdatePatient(patient);
    }
}
