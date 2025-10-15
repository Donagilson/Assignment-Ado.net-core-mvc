using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfessorManagementSystem.Models
{
    public class Professor
    {
        [Key]
        public int ProfessorId { get; set; }

        public int? HOD { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Department")]
        public int Deptno { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        [RegularExpression("^(Male|Female)$")]
        public string Gender { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public Department? Department { get; set; }
    }
}
