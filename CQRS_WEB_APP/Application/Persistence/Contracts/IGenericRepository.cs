using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        Task<List<T>> GetListAsync();
        Task<T> GetByIdAsync(int Id);

    }
}
