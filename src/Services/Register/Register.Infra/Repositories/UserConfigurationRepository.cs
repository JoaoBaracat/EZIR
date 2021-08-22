using Register.Applicatioin.Contracts.Persistence;
using Register.Domain.Entities;
using Register.Infra.Data;

namespace Register.Infra.Repositories
{
    public class UserConfigurationRepository : Repository<UserConfiguration>, IUserConfigurationRepository
    {
        public UserConfigurationRepository(RegisterContext dbContext) : base(dbContext)
        {
        }
    }
}