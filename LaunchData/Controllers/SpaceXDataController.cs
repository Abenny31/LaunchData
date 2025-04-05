using LaunchData.Data;
using LaunchData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LaunchData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceXDataController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;

        public SpaceXDataController(AppDbContext context,HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        [HttpGet("getData")]
        public async Task<IActionResult> GetLaunches()
        {
            try
            {

                if (!_context.LaunchModels.Any())
            {
                var response = await _httpClient.GetStringAsync("https://api.spacexdata.com/v5/launches");
                List<LaunchModel> launches = new List<LaunchModel>();
               
                    launches = JsonSerializer.Deserialize<List<LaunchModel>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
                if (launches != null)
                {
                    _context.LaunchModels.AddRange(launches);
                    await _context.SaveChangesAsync();
                }
            }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            return Ok(await _context.LaunchModels.ToListAsync());
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetFilteredLaunches([FromQuery] int? year, [FromQuery] int? flightNumber)
        {
            var query = _context.LaunchModels.AsQueryable();

            if (year.HasValue)
                query = query.Where(l => l.DateUtc.Year == year.Value);

            if (flightNumber.HasValue)
                query = query.Where(l => l.Id == flightNumber.ToString());

            return Ok(await query.ToListAsync());
        }

    }
}
