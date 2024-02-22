using Microsoft.AspNetCore.Mvc;
using SPAWebApi.Server.Dtos;
using SPAWebApi.Server.Entities;
using SPAWebApi.Server.Repositories;

namespace SPAWebApi.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CarController> _logger;
        private readonly ICarRepository _carRepository;

        public CarController(ILogger<CarController> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }

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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _carRepository.Delete(id);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update(CarDto carDto)
        {
            try
            {
                var entity = new Car
                {
                     Brand = carDto.Brand,
                      Color = carDto.Color,
                       Distance=carDto.Distance,
                        EngineVolume=carDto.EngineVolume,
                         Id = carDto.Id ,
                          Model = carDto.Model,
                           Year=carDto.Year 
                };
                _carRepository.Update(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
