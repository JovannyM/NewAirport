using System.Collections.Generic;
using BLL.Models;
using DAL.Entities;

namespace BLL.Interfaces
{
    public interface IService<M> where M : BaseModel
    {
        void Create(M item);
        void Delete(int id);
        void Update(M item);
        List<M> GetList();
        M GetItem(int id);
    }
}