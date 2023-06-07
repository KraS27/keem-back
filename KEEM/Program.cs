using KEEM_DAL;
using KEEM_DAL.Implementation;
using KEEM_DAL.Interfaces;
using KEEM_Domain.Entities.DB;
using KEEM_Domain.Entities.Models;
using KEEM_Service.Implementation;
using KEEM_Service.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security;

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
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => 
                {
                    options.LoginPath = "/login";
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                });
            builder.Services.AddControllers();          
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

           
            builder.Services.AddScoped<IBaseRepository<Gdk>, GdkRepository>();
            builder.Services.AddScoped<IEmissionRepository, EmissionRepository>();
            builder.Services.AddScoped<IBaseRepository<Poi>, PoiRepository>();
            builder.Services.AddScoped<IBaseRepository<User> , UserRepository>();
            builder.Services.AddScoped<IBaseRepository<Element> , ElementRepository>();
            builder.Services.AddScoped<IGdkService, GdkService>();
            builder.Services.AddScoped<IPoiService, PoiService>();
            builder.Services.AddScoped<IEmissionService, EmissionService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IElementService, ElementService>();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(s =>
            {
                s.WithOrigins("http://localhost:3000", "https://localhost:7199");
                s.AllowAnyHeader();
                s.AllowAnyMethod();
                s.AllowCredentials();               
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}