using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> parent of c6df1ce... Revert "Merge branch 'Branch_Katarina' into Branch_EvertonSantos"
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerasite.Application.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {
<<<<<<< HEAD
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

        [Required(ErrorMessage = "O campo E-mail é requerido")]
        [Display(Name = "ConfirmaSenha")]
        public string ConfirmaSenha { get; set; }
=======
>>>>>>> parent of c6df1ce... Revert "Merge branch 'Branch_Katarina' into Branch_EvertonSantos"
    }
}
