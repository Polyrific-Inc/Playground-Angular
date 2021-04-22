using Microsoft.Extensions.Logging;
using Polyrific.Project.Core;

namespace Web.API.Category
{
    public class CategoryService : BaseService<CategoryEntity>, ICategoryService
    {
        public CategoryService(IRepository<CategoryEntity> CategoryRepository, ILogger<CategoryService> logger) : base(CategoryRepository, logger)
        {
        }
    }
}
