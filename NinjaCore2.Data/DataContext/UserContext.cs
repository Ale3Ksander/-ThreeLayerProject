using Microsoft.EntityFrameworkCore;
using NinjaCore2.Domain.Models;

namespace NinjaCore2.Data.DataContext
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
