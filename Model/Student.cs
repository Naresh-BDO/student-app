using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pratices_angular_CURD.Model
{
    public class Student
    {
        // Primary key, auto-increment in SQL Server
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int stdid { get; set; }

        // Name is required; limit to 100 chars (matches VARCHAR(100))
        [Required]
        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string stdname { get; set; } = string.Empty;

        // Mobile number; limit to 15; Phone attribute for basic format validation
        [StringLength(15)]
        [Column(TypeName = "varchar(15)")]
        [Phone]
        public string? mobileno { get; set; }

        // Email; limit to 100; EmailAddress attribute for validation
        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        [EmailAddress]
        public string? email { get; set; }

        // City & State; limit to 50
        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? city { get; set; }

        [StringLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string? state { get; set; }

        // Pincode; limit to 10 (kept varchar to handle leading zeros/intl codes)
        [StringLength(10)]
        [Column(TypeName = "varchar(10)")]
        public string? pincode { get; set; }

        // Address lines; limit to 255
        [StringLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string? address1 { get; set; }

        [StringLength(255)]
        [Column(TypeName = "varchar(255)")]
        public string? address2 { get; set; }
    }
}

