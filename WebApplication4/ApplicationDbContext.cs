using Microsoft.EntityFrameworkCore;
using Clinical_Hospital_33.Models;
using System.Collections.Generic;

namespace Clinical_Hospital_33.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Vrach> Vrach { get; set; }
    }
}