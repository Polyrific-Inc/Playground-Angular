using System;

namespace Web.API.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? Updated { get; set; }
    }
}
