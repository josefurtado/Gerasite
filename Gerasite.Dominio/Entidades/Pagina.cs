namespace Gerasite.Dominio.Entidades
{
    public class Pagina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float PosicaoHorizontal { get; set; }
        public float PosicaoVertical { get; set; }
        public Menu Menu { get; set; }
        public Template Template { get; set; }
    }
}
