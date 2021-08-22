using Register.Applicatioin.Contracts.Persistence;
using Register.Domain.Entities;
using Register.Infra.Data;

namespace Register.Infra.Repositories
{
    public class OperationTypeRepository : Repository<OperationType>, IOperationTypeRepository
    {
        public OperationTypeRepository(RegisterContext dbContext) : base(dbContext)
        {
        }
    }
}