using System.ComponentModel.DataAnnotations;

namespace Web_Security_Lab_Day3.ViewModels
{
    public class UserVM
    { 

        [Key]
        public string Email { get; set; }
    }
}
