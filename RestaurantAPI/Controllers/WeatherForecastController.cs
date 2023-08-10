using Microsoft.AspNetCore.Mvc;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        
        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var result = _service.Get();
            return result;
        }

        [HttpPost]
        public ActionResult<string> Hello([FromBody] string name)
        {
            //HttpContext.Response.StatusCode = 401;
            //return StatusCode(401, $"Hello {name}");
            return NotFound($"Hello {name}");
        }

        //ZADANIE
        [HttpGet("zadanie/{min}")]
        public IEnumerable<WeatherForecast> GetZad([FromQuery]int liczba, [FromRoute]int min, [FromBody]int max)
        {
            var result = _service.Get(min, max, liczba);
            return result;
        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> PostZad([FromQuery] int liczba, [FromBody] Liczby l1)
        {
            if (liczba < 1 || l1.min > l1.max )
            {
                return BadRequest("pojeba³o?");
            }
            var result = _service.Get(l1.min, l1.max, liczba);
            return Ok(result);
            //HttpContext.Response.StatusCode = 401;
            //return StatusCode(401, $"Hello {name}");
            //return NotFound($"Hello {name}");
        }

    }
}