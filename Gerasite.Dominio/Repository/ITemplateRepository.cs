using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Interfaces;

namespace Gerasite.Dominio.Repository
{
    public interface ITemplateRepository : IRepository<Template>
    {
        Template GetByNome(string nome);
    }
}
