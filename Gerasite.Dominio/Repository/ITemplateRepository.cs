using Gerasite.Dominio.Entidades;
using Gerasite.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gerasite.Dominio.Repository
{
    public interface ITemplateRepository : IRepository<Template>
    {
        Template GetByNome(string nome);
    }
}
