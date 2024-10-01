using Bike.Api.Mappers;
using Bike.Domain.Models;
using Bike.Domain.Ports;
using Microsoft.AspNetCore.Mvc;

namespace Bike.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BikeController : ControllerBase
    {
        private readonly IBikeService _bikeService;

        public BikeController(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        [HttpGet("thefts/count")]
        public async Task<IActionResult> GetTheftsCount(string city, int distance, StolennessType stolenness)
        {

            try
            {
                var result = await _bikeService.GetTheftCountAsync(city, distance, stolenness.ToString(), HttpContext.RequestAborted);
                var response = BikeSearchCountMappers.MapToWebModel(result);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
