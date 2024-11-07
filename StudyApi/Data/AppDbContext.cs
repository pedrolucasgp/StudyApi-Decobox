using Microsoft.EntityFrameworkCore;
using StudyApi.Models;

namespace StudyApi.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options) 
        {
        }

        public DbSet<UserModel> Users { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<UserModel>()
        //        .HasIndex(u => new {u.Email, u.Username})
        //        .IsUnique(true);
        //}
        public DbSet<OpinionModel> Opinions { get; set; }

    }
}
