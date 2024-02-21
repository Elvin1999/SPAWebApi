using Microsoft.EntityFrameworkCore;
using SPAWebApi.Server.Data;
using SPAWebApi.Server.Entities;

namespace SPAWebApi.Server.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarContext _context;

        public CarRepository(CarContext context)
        {
            _context = context;
        }

        public List<Car> GetCars()
        {
            var cars=_context.Cars.ToList();
            return cars;
        }
    }
}
