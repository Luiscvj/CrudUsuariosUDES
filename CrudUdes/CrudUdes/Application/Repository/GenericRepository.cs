using CrudUdes.Domain.Interfaces;
using CrudUdes.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CrudUdes.Application.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CrudUdesContext _context;

        public GenericRepository(CrudUdesContext context)
        {
            _context = context;
        }

        public virtual async Task<T>  GetById(int Id)
        {
            return await  _context.Set<T>().FindAsync(Id);    
        }
        public virtual async  Task<IEnumerable<T>> GetAll()
        {
            return await  _context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        
    }
}
