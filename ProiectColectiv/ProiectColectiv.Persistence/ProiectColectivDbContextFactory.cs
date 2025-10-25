using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProiectColectiv.Persistence
{
    public class ProiectColectivDbContextFactory : IDesignTimeDbContextFactory<ProiectColectivDbContext>
    {
        public ProiectColectivDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProiectColectivDbContext>();
            
            var connectionString = $"Server=proiect-colectiv.cy3o4iemqcjn.us-east-1.rds.amazonaws.com,1433;Database=retro-football-from-azure;User Id=admin;Password=NN2JR208kLBOUDYSdE3E;TrustServerCertificate=true;";
            
            optionsBuilder.UseSqlServer(connectionString);

            return new ProiectColectivDbContext(optionsBuilder.Options);
        }
    }
}
