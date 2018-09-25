using System.ComponentModel.DataAnnotations;

namespace Gerasite.Application.ViewModels.AccountViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Code { get; set; }
    }
}
