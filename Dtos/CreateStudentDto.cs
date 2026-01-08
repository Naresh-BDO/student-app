using System.ComponentModel.DataAnnotations;

namespace pratices_angular_CURD.Dtos
{
    public class CreateStudentDto
    {

        [Required]
        [StringLength(100)]
        public string stdname { get; set; } = string.Empty;

        // Optional fields; keep validation consistent with entity.
        [StringLength(15)]
        [Phone] // Basic phone format validation (liberal)
        public string? mobileno { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string? email { get; set; }

        [StringLength(50)]
        public string? city { get; set; }

        [StringLength(50)]
        public string? state { get; set; }

        [StringLength(10)]
        public string? pincode { get; set; }

        [StringLength(255)]
        public string? address1 { get; set; }

        [StringLength(255)]
        public string? address2 { get; set; }
    }

}

