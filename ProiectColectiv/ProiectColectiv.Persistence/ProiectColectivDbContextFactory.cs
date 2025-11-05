using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProiectColectiv.Persistence
{
    public class ProiectColectivDbContextFactory : IDesignTimeDbContextFactory<ProiectColectivDbContext>
    {
        public ProiectColectivDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProiectColectivDbContext>();

            var connectionString = $"Server=192.168.0.111,1433;Database=ProiectColectiv;User Id=sa;Password=8SSESmkxpHLofk7kL8CZ;TrustServerCertificate=true;";

            optionsBuilder.UseSqlServer(connectionString);

            return new ProiectColectivDbContext(optionsBuilder.Options);
        }
    }
}
