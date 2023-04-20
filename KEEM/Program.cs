using KEEM_DAL;
using KEEM_DAL.Implementation;
using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.DB;
using KEEM_Service.Implementation;
using KEEM_Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace KEEM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 25))));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped <IBaseRepository<Poi>, PoiRepository>();
            builder.Services.AddScoped <IPoiService, PoiService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}