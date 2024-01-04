using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlazorShop.Api
{
    public partial class rls_tmpContext : DbContext
    {
        public rls_tmpContext()
        {
        }

        public rls_tmpContext(DbContextOptions<rls_tmpContext> options)
            : base(options)
        {
        }
        //For non prodution use. Mater of protect sensitive information.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=172.19.0.72;Port=5432;Database=rls_tmp;Username=postgres;Password=postgres")
                              .EnableSensitiveDataLogging(); // Enable sensitive data logging
            }
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseNpgsql("Host=172.19.0.72;Port=5432;Database=rls_tmp;Username=postgres;Password=postgres");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
