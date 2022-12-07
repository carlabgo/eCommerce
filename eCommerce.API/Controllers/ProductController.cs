using eCommerce.API.Models;
using eCommerce.Infrastructure.Dtos.Category;
using eCommerce.Infrastructure.Dtos.Product;
using eCommerce.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    public class ProductController : ApiBaseController
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            return Return(await _service.GetById(id).ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DtoAddProduct request)
        {
            return Return(await _service.Add(request).ConfigureAwait(false));
        }
        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> List(RequestPaginatedData request)
        {
            return Return(await _service.ListProducts(request.Filter, request.PageSize, request.Page).ConfigureAwait(false));
        }
    }
}

