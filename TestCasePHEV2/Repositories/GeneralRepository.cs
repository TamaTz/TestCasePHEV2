using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TestCasePHEV2.Contracts;
using TestCasePHEV2.Data;

namespace TestCasePHEV2.Repository
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        private readonly TestCasePHEV2DbContext _context;

        public GeneralRepository(TestCasePHEV2DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public T GetByGuid(string guid)
        {
            return _context.Set<T>().Find(guid);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity; // Mengembalikan entitas yang telah ditambahkan
        }
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
