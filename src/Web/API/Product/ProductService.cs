using Microsoft.Extensions.Logging;
using Polyrific.Project.Core;

namespace Web.API.Product
{
    public class ProductService : BaseService<ProductEntity>, IProductService
    {
        public ProductService(IRepository<ProductEntity> ProductRepository, ILogger<ProductService> logger) : base(ProductRepository, logger)
        {
        }
    }
}
