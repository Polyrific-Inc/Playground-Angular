using Polyrific.Project.Core;
using Web.API.Category;

namespace Web.API.Product
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

        public override void UpdateValueFrom(BaseEntity source)
        {
            var sourceEntity = (ProductEntity)source;
            Name = sourceEntity.Name;
            Price = sourceEntity.Price;
            CategoryId = sourceEntity.CategoryId;
            Category = sourceEntity.Category;
        }
    }
}
