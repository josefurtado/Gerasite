using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Interfaces;

namespace Gerasite.Dominio.Repository
{
    public interface ITemplateArquivadoRepository : IRepository<TemplateArquivado>
    {
        TemplateArquivado GetByNome(string nome);
    }
}
