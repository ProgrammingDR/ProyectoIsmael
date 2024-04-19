using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
