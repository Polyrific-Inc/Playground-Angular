using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polyrific.Project.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.API.Category
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService CategoryService, IMapper mapper)
        {
            _CategoryService = CategoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories(int? pageNumber, int? pageSize, string orderBy, string filter, bool desc)
        {
            var entityPaging = await _CategoryService.GetPageData(pageNumber, pageSize, orderBy, filter, desc);

            var dtoPaging = new Paging<CategoryDto>
            {
                Items = _mapper.Map<IEnumerable<CategoryDto>>(entityPaging.Items),
                Page = entityPaging.Page,
                PageSize = entityPaging.PageSize,
                TotalCount = entityPaging.TotalCount
            };

            return Ok(dtoPaging);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var entity = await _CategoryService.Get(id);
            var item = _mapper.Map<CategoryDto>(entity);

            if (item == null)
                return NotFound(id);

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto item)
        {
            var entity = _mapper.Map<CategoryEntity>(item);

            var result = await _CategoryService.Save(entity, true);
            if (!result.Success)
                return BadRequest(result.Errors);

            return Ok(_mapper.Map<CategoryDto>(result.Item));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDto item)
        {
            if (id != item.Id)
                return BadRequest("Id parameter doesn't match");

            var entity = _mapper.Map<CategoryEntity>(item);

            var result = await _CategoryService.Save(entity, false);
            if (!result.Success)
                return BadRequest(result.Errors);

            return Ok(_mapper.Map<CategoryDto>(result.Item));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _CategoryService.Delete(id);
            if (!result.Success)
                return BadRequest(result.Errors);

            return NoContent();
        }
    }
}
