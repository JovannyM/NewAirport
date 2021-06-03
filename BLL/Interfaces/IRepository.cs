using System.Collections.Generic;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Create(T item);
        void Delete(int id);
        void Update(T item);
        List<T> GetList();
        T GetItem(int id);
    }
}