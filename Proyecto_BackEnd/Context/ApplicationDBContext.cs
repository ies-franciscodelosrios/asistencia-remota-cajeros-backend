using Microsoft.EntityFrameworkCore;
using Proyecto_BackEnd.Model;

namespace Proyecto_BackEnd.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) { 

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CajeroModel> Cashiers { get; set; }
        public DbSet<CallModel> Calls { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CajeroModel>()
                .HasIndex(u => u.ip)
                .IsUnique();

            builder.Entity<CallModel>()
                .HasOne<UserModel>()
                .WithMany()
                .HasForeignKey(p => p.UserId);

            builder.Entity<CallModel>()
                .HasOne<CajeroModel>()
                .WithMany()
                .HasForeignKey(p => p.CajeroId);
        }
    }
}
