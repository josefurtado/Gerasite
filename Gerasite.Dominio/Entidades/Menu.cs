namespace Gerasite.Dominio.Entidades
{
    public class Menu
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool PaginaAdicionada { get; set; }
        public float PosicaoHorizontal { get; set; }
        public float PosicaoVertical { get; set; }
        public Template Template { get; set; }
    }
}