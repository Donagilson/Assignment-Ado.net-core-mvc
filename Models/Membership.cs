using System.ComponentModel.DataAnnotations;

namespace PatientManagementSystem2025.Models
{
    public class Membership
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        public string MemberDescrip { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Insurance Amount must be greater than or equal to 0")]
        public decimal InsureAmt { get; set; }
    }
}
