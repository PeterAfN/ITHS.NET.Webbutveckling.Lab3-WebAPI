using System.Diagnostics.CodeAnalysis;
using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Kurs> Kurser { get; set; }

        public DbSet<Deltagare> Deltagare { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

    }
}