using System;
using Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Repository.SQLServer
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected RepositoryContext _context;

        private DbSet<T> Repositoryset;
        public GenericRepository(RepositoryContext context)
        {
            _context = context;
            Repositoryset = _context.Set<T>();
        }

        public List<T> FindAll()
            => Repositoryset.ToList();

        public T FindByID(int id)
            => Repositoryset.SingleOrDefault(p => p.Id.Equals(id));

        public T Create(T value)
        {
            try
            {
                Repositoryset.Add(value);
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
            var result = Repositoryset.SingleOrDefault(p => p.Id.Equals(value.Id));
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
            var result = Repositoryset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    Repositoryset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool Exists(int id)
            => Repositoryset.Any(p => p.Id.Equals(id));
    }
}

