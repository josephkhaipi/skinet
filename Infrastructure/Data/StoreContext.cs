
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        //constructure 
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        // this properties allow use to access, query the product list from our database
        public DbSet<Product> Products { get; set; }
    }
}