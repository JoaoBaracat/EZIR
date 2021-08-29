using Microsoft.Extensions.Logging;
using Register.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Infra.Data
{
    public class RegisterContextSeed
    {
        public static async Task SeedAsync(RegisterContext orderContext, ILogger<RegisterContextSeed> logger)
        {
            if (!orderContext.UserConfigurations.Any())
            {
                orderContext.UserConfigurations.AddRange(GetPreconfiguredUserConfiguration());

                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(RegisterContext).Name);
            }

            if (!orderContext.OperationTypes.Any())
            {
                orderContext.OperationTypes.AddRange(GetPreconfiguredOperationType());

                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(RegisterContext).Name);
            }
        }

        private static IEnumerable<UserConfiguration> GetPreconfiguredUserConfiguration()
        {
            return new List<UserConfiguration>
            {
                new UserConfiguration() {Name = "joao",
                    Email = "joao@gmail.com",
                    InitialBalance = 350,
                    Id = Guid.Parse("be0ad3ba-7201-47b4-a71e-b2c65957c3f7") }
            };
        }

        private static IEnumerable<OperationType> GetPreconfiguredOperationType()
        {
            return new List<OperationType>
            {
                new OperationType() {Id = Guid.NewGuid(),
                    Description = "Stock" },
                new OperationType() {Id = Guid.NewGuid(),
                    Description = "ETF" },
                new OperationType() {Id = Guid.NewGuid(),
                    Description = "REIT" },
                new OperationType() {Id = Guid.NewGuid(),
                    Description = "BDR" },
                new OperationType() {Id = Guid.NewGuid(),
                    Description = "Mini-Index" },
                new OperationType() {Id = Guid.NewGuid(),
                    Description = "Mini-Dolar" }
            };
        }
    }
}