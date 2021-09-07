
using System.Linq;
using System.Reflection;
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
        //when we do migration the product will have a foreign key pointing to product brand and product type 
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }


        //when we create migration this metho responsible for creating migration. 
        //we override this method and tells it to look our configuration 
        protected override void OnModelCreating(ModelBuilder modelBuilder){

            //pull the base
            base.OnModelCreating(modelBuilder);

            //specify model buider and apply configuration and assembly where we have configuration
            ModelBuilder modelBuilder1 = modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if(Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite"){

                foreach(var entityType in modelBuilder.Model.GetEntityTypes()){
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType
                    == typeof(decimal));

                    foreach(var property in properties){
                        modelBuilder.Entity(entityType.Name).Property(property.Name)
                        .HasConversion<double>();
                    }
                }
            }

        }
    }
}