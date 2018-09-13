using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
namespace Gerasite.Dominio.Entidades
{
    public class Template
    {
        public int Id { get; set; }
        public string NomeTemplate { get; set; }
        public string DescricaoTemplate { get; set; }
        public string CorTemplate { get; set; }
        //public Sessao Sessao { get; set; }
        [DataType(DataType.ImageUrl)]
        public string FOTO_ENDERECO { get; set; }
        [NotMapped]
        public HttpPostedFileBase Foto { get; set; }
    }
}
