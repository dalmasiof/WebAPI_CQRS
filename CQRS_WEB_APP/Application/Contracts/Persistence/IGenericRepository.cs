using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(int Id);
        Task<List<T>> GetListAsync();
        Task<T> GetByIdAsync(int Id);

    }
}
