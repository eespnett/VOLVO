using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.Migrations
{
    public class AppDBContext: DbContext
    {
        public AppDBContext dbContext { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
          


        }
 


        public DbSet<Model> model { get; set; }

        public DbSet<Truck> truck { get; set; }
    }
}
