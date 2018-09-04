using System.ComponentModel.DataAnnotations;

namespace Gerasite.Application.ViewModels.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }

    }
}
