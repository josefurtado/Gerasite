using Gerasite.Dominio.Interfaces;
using System;

namespace Gerasite.Infra.Data.Transaction
{
    public interface IUnityOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class;

        int Commit();
    }
}
