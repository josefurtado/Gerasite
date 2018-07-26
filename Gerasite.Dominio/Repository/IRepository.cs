using System;
using System.Collections.Generic;
using System.Linq;

namespace Gerasite.Dominio.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(int id);
        void SaveChanges();
    }
}
