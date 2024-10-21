using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RobolineSoftlabApp.Domain.Models;

namespace RobolineSoftlabApp.Infrastructure.Data
{
    public class RobolineSoftlabAppContext : DbContext
    {
        public RobolineSoftlabAppContext(DbContextOptions<RobolineSoftlabAppContext> options)
            : base(options)
        {
        }

        public DbSet<ProductCategory> ProductCategories { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
    }
}
