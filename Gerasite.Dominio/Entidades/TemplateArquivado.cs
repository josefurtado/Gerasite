using System;
using System.ComponentModel.DataAnnotations;

namespace Gerasite.Dominio.Entidades
{
    public class TemplateArquivado
    {
        public int Id { get; set; }
        //public DateTime DataCriacao { get; set; }
        //public string NomeTemplate { get; set; }
        //public Template Template { get; set; }
        //public Usuario Usuario { get; set; }
        public string IdUsuario { get; set; }
        public int IdTemplate { get; set; }
        public int IdTipoTemplate { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Imagem { get; set; }
    }
}
