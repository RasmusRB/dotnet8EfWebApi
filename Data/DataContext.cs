using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityTestApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityTestApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}