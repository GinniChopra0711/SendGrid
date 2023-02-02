using System.ComponentModel.DataAnnotations;

namespace Web_Security_Lab_Day3.ViewModels
{
    public class UserRoleVM
    {

        [Key]
        public int ID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Role { get; set; }

    }
}
