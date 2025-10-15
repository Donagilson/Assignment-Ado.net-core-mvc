using ProfessorManagementSystem.Models;
using System.Collections.Generic;

namespace ProfessorManagementSystem.Repository
{
    public interface IProfessorRepository
    {
        IEnumerable<Professor> SelectAllProfessors();
        void InsertProfessor(Professor professor);
        List<Department> SelectAllDepartments();
        void UpdateProfessor(Professor professor);
        Professor GetProfessorById(int id); // ✅ fix parameter name/type
    }
}
