using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coursApiRest.Models
{
    public class DataDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Product> Products { get; set; }

        private static DataDbContext instance = null;

        public static DataDbContext Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataDbContext();
                return instance;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\coursM2i;Initial Catalog=api;Integrated Security=True");
        }
    }
}
