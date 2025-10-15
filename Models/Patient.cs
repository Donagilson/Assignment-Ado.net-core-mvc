using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientManagementSystem2025.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string RegistrationNo { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string PatientName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required]
        [RegularExpression(@"^(Male|Female)$", ErrorMessage = "Gender must be Male or Female")]
        public string Gender { get; set; }

        public string Address { get; set; }

        [Phone]
        public string PhoneNo { get; set; }

        [ForeignKey("Membership")]
        public int MemberId { get; set; }

        public bool IsActive { get; set; }

        public Membership? Membership { get; set; }
    }
}
