using System;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.SQLServer
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected DataContext _context;

        private DbSet<T> dataset;
        public GenericRepository(DataContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public List<T> FindAll()
            => dataset.ToList();

        public T FindByID(int id)
            => dataset.SingleOrDefault(p => p.Id.Equals(id));

        public T Create(T value)
        {
            try
            {
                dataset.Add(value);
                _context.SaveChanges();
                return value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Update(T value)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(value.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(value);
                    _context.SaveChanges();
                    return result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
                return null;
        }

        public void Delete(int id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(int id)
            => dataset.Any(p => p.Id.Equals(id));
    }
}

