using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvcT.Models;

namespace SalesWebMvcT.Data
{
    public class SalesWebMvcTContext : DbContext
    {
        public SalesWebMvcTContext (DbContextOptions<SalesWebMvcTContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
