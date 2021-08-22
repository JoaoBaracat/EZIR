using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Register.Applicatioin.Contracts.Persistence;
using Register.Infra.Data;
using Register.Infra.Repositories;
using System;

namespace Register.Infra
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<RegisterContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("RegisterConnectionString"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOperationRepository, OperationRepository>();
            services.AddScoped<IOperationTypeRepository, OperationTypeRepository>();
            services.AddScoped<IStockBrokerRepository, StockBrokerRepository>();
            services.AddScoped<IUserConfigurationRepository, UserConfigurationRepository>();

            return services;
        }
    }
}