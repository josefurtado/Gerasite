using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Gerasite.Dominio.Entidades.Templates
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Profissao { get; set; }
        public string Texto1 { get; set; }
        public string Texto2 { get; set; }
        public string Citacao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        [DataType(DataType.ImageUrl)]
        public string CaminhoImg1 { get; set; }
        [DataType(DataType.ImageUrl)]
        public string CaminhoImg2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ArquivoImg1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ArquivoImg2 { get; set; }
    }
}
