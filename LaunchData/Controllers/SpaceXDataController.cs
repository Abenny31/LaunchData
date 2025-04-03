using Microsoft.AspNetCore.Mvc;

namespace LaunchData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceXDataController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public SpaceXDataController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetLaunches()
        {
            var response = await _httpClient.GetStringAsync("https://api.spacexdata.com/v4/launches");
            return Ok(response); 
        }
    }
}
