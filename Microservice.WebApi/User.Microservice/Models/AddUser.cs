using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace User.Microservice.Models
{
    public class AddUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
       
        [MaxLength(6)]
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
    }
}
