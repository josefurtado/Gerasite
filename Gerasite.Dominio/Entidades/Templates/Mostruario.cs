using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Gerasite.Dominio.Entidades.Templates
{
    public class Mostruario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string TituloSessao1 { get; set; }
        public string TituloSessao2 { get; set; }
        public string TextoSessao2 { get; set; }
        public string TituloSessao3 { get; set; }
        public string TextoSessao3 { get; set; }
        public string TituloSessao4 { get; set; }
        public string TextoSessao4 { get; set; }
        public string LegendaImg1 { get; set; }
        public string LegendaImg2 { get; set; }
        public string LegendaImg3 { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Img1 { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Img2 { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Img3 { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Img4 { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Img5 { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Img6 { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Img7 { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Img8 { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Img9 { get; set; }

        [NotMapped]
        public HttpPostedFileBase ArquivoImg1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ArquivoImg2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ArquivoImg3 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ArquivoImg4 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ArquivoImg5 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ArquivoImg6 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ArquivoImg7 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ArquivoImg8 { get; set; }
        [NotMapped]
        public HttpPostedFileBase ArquivoImg9 { get; set; }
    }
}
