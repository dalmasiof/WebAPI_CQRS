using Application.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyContext _ctx;
        public GenericRepository(MyContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<T> Create(T entity)
        {
            await _ctx.Set<T>().AddAsync(entity);
            await _ctx.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
         
            if (await _ctx.SaveChangesAsync() > 0)
                return true;
            else
                return false;
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _ctx.Set<T>().FindAsync(Id);
            
        }

        public async Task<List<T>> GetListAsync()
        {
            return await _ctx.Set<T>().ToListAsync();

        }

        public async Task<T> Update(T entity)
        {
            _ctx.Set<T>().Update(entity);
            await _ctx.SaveChangesAsync();

            return entity;
        }
    }
}
