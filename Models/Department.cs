using System.ComponentModel.DataAnnotations;

namespace ProfessorManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; } = string.Empty;
    }
}
