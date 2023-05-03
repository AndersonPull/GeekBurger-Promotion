using System;
using Repository.Model;

namespace Repository.SQLServer
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T value);
        T FindByID(int id);
        List<T> FindAll();
        T Update(T value);
        void Delete(int id);
        bool Exists(int id);
    }
}