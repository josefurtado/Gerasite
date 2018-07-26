using System;

namespace Gerasite.Dominio.Entidades
{
    public class TemplateArquivado
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public String NomeTemplate { get; set; }
        public Template Template { get; set; }
        public Usuario Usuario { get; set; }
    }
}
