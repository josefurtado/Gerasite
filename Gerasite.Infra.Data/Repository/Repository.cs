﻿using Gerasite.Dominio.Interfaces;
using Gerasite.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Gerasite.Infra.Data.Repositorio
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly GerasiteContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(GerasiteContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            SaveChanges();
        }
    }
}
