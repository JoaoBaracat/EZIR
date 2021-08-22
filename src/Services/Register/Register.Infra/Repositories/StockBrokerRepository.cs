using Register.Applicatioin.Contracts.Persistence;
using Register.Domain.Entities;
using Register.Infra.Data;

namespace Register.Infra.Repositories
{
    public class StockBrokerRepository : Repository<StockBroker>, IStockBrokerRepository
    {
        public StockBrokerRepository(RegisterContext dbContext) : base(dbContext)
        {
        }
    }
}