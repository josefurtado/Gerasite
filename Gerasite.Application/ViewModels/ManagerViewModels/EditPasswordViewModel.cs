using System.ComponentModel.DataAnnotations;

namespace Gerasite.Application.ViewModels.ManagerViewModels
{
    public class EditPasswordViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string ConfirmaSenha { get; set; }

    }
}
