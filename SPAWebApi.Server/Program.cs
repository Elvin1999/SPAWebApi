
using Microsoft.EntityFrameworkCore;
using SPAWebApi.Server.Data;
using SPAWebApi.Server.Repositories;

namespace SPAWebApi.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var conn = builder.Configuration.GetConnectionString(NamesConstants.LocalConnection);


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader());
            });

            builder.Services.AddDbContext<CarContext>(opt =>
            {
                opt.UseSqlServer(conn);
            });
            builder.Services.AddScoped<ICarRepository, CarRepository>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => builder.AllowAnyOrigin()); // Allow requests from any origin
            app.UseCors(builder => builder.WithOrigins("https://localhost:7299")); // Allow requests only from domain.com
            app.UseCors(builder => builder.AllowAnyHeader()); // Allow any header in the request
            app.UseCors(builder => builder.AllowAnyMethod()); // Allow any HTTP method in the request
                                                              //app.UseCors(MyAllowSpecificOrigins);
            


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
