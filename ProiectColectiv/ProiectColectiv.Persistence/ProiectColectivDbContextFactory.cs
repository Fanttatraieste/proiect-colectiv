using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProiectColectiv.Persistence
{
    public class ProiectColectivDbContextFactory : IDesignTimeDbContextFactory<ProiectColectivDbContext>
    {
        public ProiectColectivDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProiectColectivDbContext>();

            var connectionString = $"Server=DESKTOP-JTS2C9N\\SQLEXPRESS;Database=ProiectColectiv;User Id=sa;Password='NE4sC5,)KA9;Ij9!!314';TrustServerCertificate=true;";

            optionsBuilder.UseSqlServer(connectionString);

            return new ProiectColectivDbContext(optionsBuilder.Options);
        }
    }
}
