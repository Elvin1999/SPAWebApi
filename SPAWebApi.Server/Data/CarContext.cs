using Microsoft.EntityFrameworkCore;
using SPAWebApi.Server.Entities;

namespace SPAWebApi.Server.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
    }
}
