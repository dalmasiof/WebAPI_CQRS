using Application.Persistence.Contracts;
using Domain.Entities;

namespace Persistence.Repositories
{
    public class CostumerRepository : GenericRepository<Costumer>, ICostumerRepository
    {
        public CostumerRepository(MyContext ctx):base(ctx)
        {

        }
    }
}
