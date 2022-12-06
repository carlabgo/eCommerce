using eCommerce.Infrastructure.OperationResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Services.Client;

namespace eCommerce.API.Controllers
{
    [ApiVersion("1")]
    [Route("api/v1/[controller]")]
    [ApiController]
    //[Authorize]
    public class ApiBaseController : ControllerBase
    {
        public IActionResult Return<T>(OperationResponse<T> response)
        {
            if (response.Success)
            {
                return Ok(response.Data);
            }
            return BadRequest(response.Exception);
        }
    }
}
