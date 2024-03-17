using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BirthflowMicroServices.Infraestructure
{
    public class BirthFlowDbContextFactory : IDesignTimeDbContextFactory<BirthFlowDbContext>
    {
        public BirthFlowDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<BirthFlowDbContext>();
            var connectionString = configuration.GetConnectionString("Birthflow");
            builder.UseSqlServer(connectionString);

            return new BirthFlowDbContext(builder.Options);
        }
    }
}