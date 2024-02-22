using SPAWebApi.Server.Entities;

namespace SPAWebApi.Server.Repositories
{
    public interface ICarRepository
    {
        List<Car> GetCars();
        void Delete(int id);
        void Update(Car car);
    }
}
