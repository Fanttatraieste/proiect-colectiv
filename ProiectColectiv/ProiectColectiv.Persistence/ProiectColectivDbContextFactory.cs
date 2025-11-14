using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProiectColectiv.Persistence
{
    public class ProiectColectivDbContextFactory : IDesignTimeDbContextFactory<ProiectColectivDbContext>
    {
        public ProiectColectivDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProiectColectivDbContext>();
            var connectionString = $"Server=localhost;Database=ProiectColectiv;Trusted_Connection=True;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);

            return new ProiectColectivDbContext(optionsBuilder.Options);
        }
    }
}
