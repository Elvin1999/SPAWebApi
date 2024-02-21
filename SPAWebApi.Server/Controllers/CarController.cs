using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPAWebApi.Server.Dtos;
using SPAWebApi.Server.Repositories;

namespace SPAWebApi.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet("GetSpecialCars")]
        public IEnumerable<CarDto> GetCars()
        {
            var result =  _carRepository.GetCars();
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
