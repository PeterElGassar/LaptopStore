namespace API.DTOs
{
    public class ProductDto
    {

        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double price { get; set; }

        public string ProductType { get; set; }

        public string ProductBrand { get; set; }
    }
}