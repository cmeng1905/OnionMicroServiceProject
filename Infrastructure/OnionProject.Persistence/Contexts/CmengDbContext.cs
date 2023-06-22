using Microsoft.EntityFrameworkCore;
using OnionProject.Domain.Entities.Product;
using OnionProject.Domain.Entities.User;

namespace OnionProject.Persistence.Contexts
{
    public class CmengDbContext : DbContext
    {
        public CmengDbContext(DbContextOptions<CmengDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        public DbSet<User> User { get; set; }

        public DbSet<Urun> Urun { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserRole>()
                .HasKey(p => new { p.RoleID, p.UserID });

            base.OnModelCreating(modelBuilder);
        }
    }
}
