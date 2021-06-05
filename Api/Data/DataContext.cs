using System.Diagnostics.CodeAnalysis;
using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Kurs> Kurser { get; set; }

        public DbSet<Deltagare> Deltagare { get; set; }

        public DbSet<KursDeltagare> KursDeltagare { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        // }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KursDeltagare>()
                .HasKey(kd => new { kd.KursId, kd.DeltagareId });
        }
    }
}