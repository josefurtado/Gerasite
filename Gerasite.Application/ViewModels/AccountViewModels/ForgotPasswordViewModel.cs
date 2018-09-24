using System.ComponentModel.DataAnnotations;

namespace Gerasite.Application.ViewModels.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}
