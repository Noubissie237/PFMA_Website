using Microsoft.EntityFrameworkCore;
using PFMA_Website.Model;

namespace PFMA_Website.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
