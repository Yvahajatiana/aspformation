using ElectionApps.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectionApps.Data
{
    public class ElectionContext:DbContext
    {
        public ElectionContext(DbContextOptions<ElectionContext> options):base(options)
        {

        }

        public DbSet<Elector> Electors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Elector>().ToTable("Elector");
        }
    }
}
