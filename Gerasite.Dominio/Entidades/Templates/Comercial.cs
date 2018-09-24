using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Gerasite.Dominio.Entidades.Templates
{
    public class Comercial
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string TextoSobre { get; set; }
        public string TextoCitacao { get; set; }
        public string TextoFuncionamento{ get; set; }
        public string TituloPrato1 { get; set; }
        public string TextoPrato1 { get; set; }
        public string TituloPrato2 { get; set; }
        public string TextoPrato2 { get; set; }
        public string TituloPrato3 { get; set; }
        public string TextoPrato3 { get; set; }
        public string TituloPrato4 { get; set; }
        public string TextoPrato4 { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }

        [DataType(DataType.ImageUrl)]
        public string CapaImg1 { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Img2 { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Img3 { get; set; }

        [NotMapped]
        public HttpPostedFileBase ArquivoImg1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ArquivoImg2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ArquivoImg3 { get; set; }
    }
}
