using SPAWebApi.Server.Entities;

namespace SPAWebApi.Server.Repositories
{
    public interface ICarRepository
    {
        List<Car> GetCars();
    }
}
