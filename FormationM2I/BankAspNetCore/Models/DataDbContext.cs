﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAspNetCore.Models
{
    public class DataDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Operation> Operations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\coursM2I;Initial Catalog=banque;Integrated Security=True");
        }

        private static DataDbContext _instance = null;

        public static DataDbContext Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataDbContext();
                return _instance;
            }
        }

        public DataDbContext()
        {

        }
    }
}
