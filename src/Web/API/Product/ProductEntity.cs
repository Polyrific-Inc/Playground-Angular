using Polyrific.Project.Core;
using System;

namespace Web.API.Product
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public override void UpdateValueFrom(BaseEntity source)
        {
            var sourceEntity = (ProductEntity)source;
            Name = sourceEntity.Name;
            Price = sourceEntity.Price;
        }
    }
}
