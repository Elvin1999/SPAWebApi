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

        public void Delete(int id)
        {
            var car = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                _context.SaveChanges();
            }
        }

        public List<Car> GetCars()
        {
            var cars=_context.Cars.ToList();
            return cars;
        }

        public void Update(Car car)
        {
            if(car != null) { 
                _context.Cars.Update(car);
                _context.SaveChanges();
            }
        }
    }
}
