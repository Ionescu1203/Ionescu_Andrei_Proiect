using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ionescu_Andrei_Proiect.Models;

namespace Ionescu_Andrei_Proiect.Data
{
    public class Ionescu_Andrei_ProiectContext : DbContext
    {
        public Ionescu_Andrei_ProiectContext (DbContextOptions<Ionescu_Andrei_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Ionescu_Andrei_Proiect.Models.Product> Product { get; set; }

        public DbSet<Ionescu_Andrei_Proiect.Models.ProductSupplier> ProductSupplier { get; set; }

        public DbSet<Ionescu_Andrei_Proiect.Models.Category> Category { get; set; }
    }
}
