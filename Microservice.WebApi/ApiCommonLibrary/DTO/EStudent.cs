using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCommonLibrary.DTO
{
    public class EStudent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string City { get; set; }

        [MinLength(6),MaxLength(6)]
        public string Pin { get; set; }
        [MaxLength(50)]
        public string State { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        public string Role { get; set; } = "Student";
    }

    public class StudentCourse
    {
        public int Id { get; set; }
        public EStudent EStudent { get; set; }
        public Course Course { get; set; }
    }
}
