namespace DroughtProject.Controllers {

using Microsoft.AspNetCore.Mvc;
    using DroughtProject.Services;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class SequiaDataController : ControllerBase
    {
        private readonly SequiaDataService _sequiaDataService;

        public SequiaDataController(SequiaDataService sequiaDataService)
        {
            _sequiaDataService = sequiaDataService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var incendis = await _sequiaDataService.FetchDataFromApiAsync();
                return Ok(incendis);
            }
            catch (HttpRequestException e)
            {
                return StatusCode(500, "Request error: " + e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "An error occurred: " + e.Message);
            }
        }
    }
}
