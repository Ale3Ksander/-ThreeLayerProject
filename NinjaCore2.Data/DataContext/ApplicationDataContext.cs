using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NinjaCore2.Data.Configurations;
using NinjaCore2.Data.Entities;

namespace NinjaCore2.Data.DataContext
{
    public class ApplicationDataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<User> Users { get; set; }

        public ApplicationDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
