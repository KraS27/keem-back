using KEEM_DAL;
using KEEM_DAL.Implementation;
using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.DB;
using KEEM_Domain.Entities.Models;
using KEEM_Service.Implementation;
using KEEM_Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddCors();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
            builder.Services.AddControllers();          
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IBaseRepository<Gdk>, GdkRepository>();
            builder.Services.AddScoped<IBaseRepository<Emission>, EmissionRepository>();
            builder.Services.AddScoped<IBaseRepository<Poi>, PoiRepository>();
            builder.Services.AddScoped<IGdkService, GdkService>();
            builder.Services.AddScoped<IPoiService, PoiService>();
            builder.Services.AddScoped<IEmissionService, EmissionService>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(b => b.AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}