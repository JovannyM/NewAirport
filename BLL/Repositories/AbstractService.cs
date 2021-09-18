using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Context;
using DAL.Entities;

namespace BLL.Repositories
{
    public class AbstractService<D,M> : IService<M> where D: BaseEntity where M: BaseModel
    {
        protected readonly BaseContext DB;
        protected readonly DbSet<D> DbSet;
        protected Mapper toDal;
        protected Mapper toModel;
        protected readonly IUnitOfWork UOW;
        
        public AbstractService(BaseContext db, DbSet<D> dbSet, IUnitOfWork uow)
        {
            DB = db;
            DbSet = dbSet;
            UOW = uow;
        }
        
        public virtual void Create(M item)
        { 
            D d = toDal.Map<D>(item);
            DbSet.Add(d);
            UOW.Save();
        }

        public virtual void Delete(int id)
        {
            D item = DbSet.Find(id);
            if (item != null) DbSet.Remove(item);
            UOW.Save();
        }

        public virtual void Update(M model)
        {
            D updatedItem = DbSet.Find(model.Id);
            toDal.Map<M, D>(model, updatedItem);
            DB.Entry(updatedItem).State = EntityState.Modified;
            UOW.Save();
        }

        public virtual List<M> GetList()
        {
            var listD = DbSet.ToList();
            var listModels = toModel.Map<List<D>,List<M>>(listD);
            return listModels;
        }

        public virtual M GetItem(int id)
        {
            var d = DbSet.Find(id);
            var model = toModel.Map<M>(d);
            return model;
        }
    }
}