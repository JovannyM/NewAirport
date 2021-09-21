using System.Collections.Generic;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IService<M> where M : BaseModel
    {
        void Create(M item);
        (bool isDeleted, string messages) Delete(int id);
        void Update(M item);
        List<M> GetList();
        M GetItem(int id);
    }
}