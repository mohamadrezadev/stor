using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BEE;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL
{
    public class db : IdentityDbContext<User>
    {
        public db() : base() { }
        public db(DbContextOptions<db> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=webstor;trusted_connection=true;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<teacher> Teachers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<blog> Blogs { get; set; }
        public DbSet<cours> courss { get; set; }
        public DbSet<techer_Cours> techerCourss { get; set; }
        public DbSet<cours_deteilfile> cours_Deteilfiles { get; set; }
        public DbSet<Order_cours> order_Courss { get; set; }

    }
}
