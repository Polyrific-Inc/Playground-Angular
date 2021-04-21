using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Polyrific.Project.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.API.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _ProductService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService ProductService, IMapper mapper)
        {
            _ProductService = ProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(int? pageNumber, int? pageSize, string orderBy, string filter, bool desc)
        {
            var entityPaging = await _ProductService.GetPageData(pageNumber, pageSize, orderBy, filter, desc);

            var dtoPaging = new Paging<ProductDto>
            {
                Items = _mapper.Map<IEnumerable<ProductDto>>(entityPaging.Items),
                Page = entityPaging.Page,
                PageSize = entityPaging.PageSize,
                TotalCount = entityPaging.TotalCount
            };

            return Ok(dtoPaging);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var entity = await _ProductService.Get(id);
            var item = _mapper.Map<ProductDto>(entity);

            if (item == null)
                return NotFound(id);

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto item)
        {
            var entity = _mapper.Map<ProductEntity>(item);

            var result = await _ProductService.Save(entity, true);
            if (!result.Success)
                return BadRequest(result.Errors);

            return Ok(_mapper.Map<ProductDto>(result.Item));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto item)
        {
            if (id != item.Id)
                return BadRequest("Id parameter doesn't match");

            var entity = _mapper.Map<ProductEntity>(item);

            var result = await _ProductService.Save(entity, false);
            if (!result.Success)
                return BadRequest(result.Errors);

            return Ok(_mapper.Map<ProductDto>(result.Item));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _ProductService.Delete(id);
            if (!result.Success)
                return BadRequest(result.Errors);

            return NoContent();
        }
    }
}
