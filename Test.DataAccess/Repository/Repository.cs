using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test.DataAccess.Data;
using Test.DataAccess.Repository.IRepository;
using Test.Models;

namespace Test.DataAccess.Repository
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> Set;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            Set = _db.Set<T>();
        }
        public void Add(T entity)
        {
            Set.Add(entity);
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            Set.RemoveRange(entities);
        }

        public T Get(Expression<Func<T, bool>> fillter)
        {
            IQueryable<T> query = Set;
            query = query.Where(fillter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = Set;
            return query.ToList();
        }
    }
}
