using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Datas
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
