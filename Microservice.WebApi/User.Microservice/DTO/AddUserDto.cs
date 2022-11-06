using System.ComponentModel.DataAnnotations;

namespace User.Microservice.DTO
{
    public class AddUserDto
    {
        [Required(ErrorMessage = "name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "city is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "pin is required")]
        public int Pin { get; set; }
        [Required(ErrorMessage = "state is required")]
        public string State { get; set; }
        [Required(ErrorMessage = "contact is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "password is required")]
        public string Password { get; set; }
        
    }
}
