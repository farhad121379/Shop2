using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domon1.ENtityes;
using Microsoft.EntityFrameworkCore;
namespace core.Deta
{
    class Shop2DB:DbContext

    {
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=shop2;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<kala>().Property(p => p.name).HasMaxLength(50);
        }
        public DbSet<kala> kala { get; set; }
        public DbSet<Gropkala> Gropkala { get; set; }

    }
}
