using System.ComponentModel.DataAnnotations;

namespace MG.Auth.Models.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}