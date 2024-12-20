using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ux_newdata.application.interfaces;
using ux_newdata.domain.DTO;

namespace ux_newdata.api.Controllers
{
    [ApiController]
    [Route("api/Consulta/[controller]")]
    public class ApiController : ControllerBase
    {
       private readonly IApi _api;
        public ApiController(IApi api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> GetApi()
        {
            try
            {
                List<ApiDto> apiData = await _api.GetApi();
                return Ok(apiData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
