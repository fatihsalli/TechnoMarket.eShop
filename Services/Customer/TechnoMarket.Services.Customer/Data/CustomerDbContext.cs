﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace TechnoMarket.Services.Customer.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }

        public DbSet<Models.Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Add the Postgres Extension for UUID generation
            //modelBuilder.HasDefaultSchema("Fatih");

            //Configuration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

    }
}
