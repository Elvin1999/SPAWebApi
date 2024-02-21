using Microsoft.AspNetCore.Mvc;
using SPAWebApi.Server.Dtos;
using SPAWebApi.Server.Repositories;

namespace SPAWebApi.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICarRepository _carRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet(Name = "GetCar")]
        public IEnumerable<CarDto> Get()
        {
            var result = _carRepository.GetCars();
            var dtos = result.Select(c =>
            {
                return new CarDto
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Color = c.Color,
                    Distance = c.Distance,
                    EngineVolume = c.EngineVolume,
                    Model = c.Model,
                    Year = c.Year
                };
            }).ToArray();
            return dtos;
        }
    }
}
