using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-E6N8VGF\\SQLEXPRESS;Database=Clinical_Hospital_33;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
            }
        }


        public DbSet<Vrach> Vrachs { get; set; }
        
    }
 }
