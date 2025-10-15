using ProfessorManagementSystem.Models;
using ProfessorManagementSystem.Repository;
using System.Collections.Generic;

namespace ProfessorManagementSystem.Services
{
    public class ProfessorServiceImpl : IProfessorService
    {
        private readonly IProfessorRepository _repository;

        public ProfessorServiceImpl(IProfessorRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Professor> GetAllProfessors()
        {
            return _repository.SelectAllProfessors();
        }

        public void AddProfessor(Professor professor)
        {
            _repository.InsertProfessor(professor);
        }

        public List<Department> GetAllDepartments()
        {
            return _repository.SelectAllDepartments();
        }

        public void UpdateProfessor(Professor professor)
        {
            _repository.UpdateProfessor(professor);
        }

        public Professor GetProfessorById(int id)   // ✅ fixed
        {
            return _repository.GetProfessorById(id);
        }

        public Professor GetProfessorById()
        {
            throw new NotImplementedException();
        }
    }
}
