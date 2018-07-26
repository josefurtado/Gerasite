namespace Gerasite.Dominio.Entidades
{
    public class Logo
    {
        public int Id { get; set; }
        public string CaminhoImagem { get; set; }
        public string ArquivoImagem { get; set; }
        public Template Template { get; set; }
    }
}
