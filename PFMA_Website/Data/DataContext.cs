using Microsoft.EntityFrameworkCore;
using PFMA_Website.Model;
using PFMA_Website.Model.Acteurs.Directs;
using PFMA_Website.Model.Acteurs.Indirect;

namespace PFMA_Website.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Producteur> Producteurs { get; set; }
        public DbSet<Vendeur> Vendeurs { get;set; }
    }
}
