using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RobolineSoftlabApp.Domain.Models;

namespace RobolineSoftlabApp.Data
{
    public class RobolineSoftlabAppContext : DbContext
    {
        public RobolineSoftlabAppContext (DbContextOptions<RobolineSoftlabAppContext> options)
            : base(options)
        {
        }

        public DbSet<RobolineSoftlabApp.Domain.Models.ProductCategory> ProductCategory { get; set; } = default!;
        public DbSet<RobolineSoftlabApp.Domain.Models.Product> Product { get; set; } = default!;
    }
}
