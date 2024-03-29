﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
// ReSharper disable InconsistentNaming

namespace BLL.Repositories
{
    public class AbstractRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected BaseContext DB;
        protected DbSet<T> DbSet;
        
        public AbstractRepository(BaseContext db, DbSet<T> dbSet)
        {
            DB = db;
            DbSet = dbSet;
        }

        public virtual void Create(T item)
        {
            DbSet.Add(item);
        }

        public virtual void Delete(int id)
        {
            T item = DbSet.Find(id);
            if (item != null) DbSet.Remove(item);
        }

        public virtual void Update(T item)
        {
            DB.Entry(item).State = EntityState.Modified;
        }

        public virtual List<T> GetList()
        {
            return DbSet.ToList();
        }

        public virtual T GetItem(int id)
        {
            return DbSet.Find(id);
        }
    }
}