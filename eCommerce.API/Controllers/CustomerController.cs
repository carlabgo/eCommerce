using eCommerce.API.Models;
using eCommerce.Infrastructure.Dtos.Customer;
using eCommerce.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    public class CustomerController : ApiBaseController
    {
        private readonly CustomerService _service;

        public CustomerController(CustomerService service)
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
        public async Task<IActionResult> Post([FromBody] DtoAddCustomer request)
        {
            return Return(await _service.Add(request).ConfigureAwait(false));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] DtoEditCustomer request)
        {
            return Return(await _service.Update(request).ConfigureAwait(false));
        }
        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> List(RequestPaginatedData request)
        {
            return Return(await _service.ListCustomers(request.Filter, request.PageSize, request.Page).ConfigureAwait(false));
        }
    }
}

