using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SytnerTest.Models;
using Microsoft.EntityFrameworkCore;

namespace SytnerTest.Data
{
    //Adding context for Cars Database
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<car> cars { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<car>().ToTable("car");
        }
    }
}
