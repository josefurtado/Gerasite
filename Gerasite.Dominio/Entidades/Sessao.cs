using System;

namespace Gerasite.Dominio.Entidades
{
    public class Sessao
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataInicioSessao { get; set; }
    }
}
