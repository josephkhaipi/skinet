using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    //Adding seed data 
    public class StoreContextSeed
    {
        //static keyword allow us to use a method inside the class 
        //without actually needing to create a new Instance of the class before we can use the method
        public static async Task SeedAsync(StoreContext context, ILoggerFactory looggerFactory)
        {
            try
            {
                //check to see if we got our product brand in our database
                //if not see give a path to our seed data 
                if (!context.ProductBrands.Any())
                {

                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");

                    //serialize what is inside the json (brandData) into product brand object database
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    //loop or track all of items after deserialize and added item into the product brand
                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }

                    //save in the StoreContext this will save all our new product brand into our database 
                    await context.SaveChangesAsync();
                }


                //this is for Product Type
                //check to see if we got our product brand in our database
                //if not see give a path to our seed data 
                if (!context.ProductTypes.Any())
                {

                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");

                    //serialize what is inside the json (brandData) into product brand object database
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    //loop or track all of items after deserialize and added item into the product brand
                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    //save in the StoreContext this will save all our new product brand into our database 
                    await context.SaveChangesAsync();
                }

                //this is for Product
                //check to see if we got our product brand in our database
                //if not see give a path to our seed data 
                if (!context.Products.Any())
                {

                    var productsData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");

                    //serialize what is inside the json (brandData) into product brand object database
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    //loop or track all of items after deserialize and added item into the product brand
                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    //save in the StoreContext this will save all our new product brand into our database 
                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger =  looggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }

        }

    }
}