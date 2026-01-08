using Microsoft.EntityFrameworkCore;
using MVCPustokApp.Models;

namespace MVCPustokApp.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feature> Features { get; set; }
        


        }
}
