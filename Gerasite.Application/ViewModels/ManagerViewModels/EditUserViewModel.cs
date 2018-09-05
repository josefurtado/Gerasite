using System.ComponentModel.DataAnnotations;

namespace Gerasite.Application.ViewModels.ManagerViewModels
{
    public class EditUserViewModel
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
    }
}