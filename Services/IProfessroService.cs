using ProfessorManagementSystem.Models;
using System.Collections.Generic;

namespace ProfessorManagementSystem.Services
{
    public interface IProfessorService
    {
        IEnumerable<Professor> GetAllProfessors();
        void AddProfessor(Professor professor);
        List<Department> GetAllDepartments();

        void UpdateProfessor(Professor professor);
        Professor GetProfessorById(int id); // ✅ fixed: accepts id parameter
        Professor GetProfessorById();
    }
}
