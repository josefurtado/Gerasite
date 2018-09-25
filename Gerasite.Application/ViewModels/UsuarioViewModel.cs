using System.ComponentModel.DataAnnotations;

namespace Gerasite.Application.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é requerido")]
        [MaxLength(60, ErrorMessage = "Tamanho máximo de {0} caracteres")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo E-mail é requerido")]
        [MaxLength(60, ErrorMessage = "Tamanho máximo de {0} caracteres")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo E-mail é requerido")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
    }
}
