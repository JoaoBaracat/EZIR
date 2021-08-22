using Register.Applicatioin.Contracts.Persistence;
using Register.Domain.Entities;
using Register.Infra.Data;

namespace Register.Infra.Repositories
{
    public class OperationRepository : Repository<Operation>, IOperationRepository
    {
        public OperationRepository(RegisterContext dbContext) : base(dbContext)
        {
        }
    }
}