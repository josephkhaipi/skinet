namespace Core.Entities
{
    public class Product : BaseEntity
    {
        //entities this entitites will related to database 
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }  
        public string PictureUrl { get; set; }

        //to help out entity framework
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
   
    }
}