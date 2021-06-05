using System;
using System.Collections.Generic;
using System.Text;

namespace PetShopLib.Interfaces
{
    public interface IRepository<T>
    {
        T GetById (int id);
        List<T> GetAll();
        void Add(T obj);
        void DeleteById(int id);
        void Update(T obj);
    }
}
