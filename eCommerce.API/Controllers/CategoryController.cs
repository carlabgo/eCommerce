using eCommerce.API.Models;
using eCommerce.Infrastructure.Dtos.Category;
using eCommerce.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace eCommerce.API.Controllers
{
    public class CategoryController : ApiBaseController
    {
        private readonly CategoryService _service;

        public CategoryController(CategoryService service) 
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
        public async Task<IActionResult> Post([FromBody] DtoAddCategory request)
        {
            return Return(await _service.Add(request).ConfigureAwait(false));
        }
        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> List(RequestPaginatedData request)
        {
            return Return(await _service.ListCategories(request.Filter, request.PageSize, request.Page).ConfigureAwait(false));
        }
    }
}
