using kuaforsalonu.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OpenAI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
namespace kuaforsalonu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // OpenAIService ve HttpClient'ı DI container'a ekliyoruz
            builder.Services.AddHttpClient<OpenAIService>();
            builder.Services.AddScoped<OpenAIService>();

            // Diğer servisleri ekliyoruz
            builder.Services.AddControllersWithViews();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Kuaforsalonu>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.Cookie.Name = "NetCoreMvc.Auth";
                options.LoginPath = "/Login/Login";
            });

            // OpenAI API'yi yapılandırma
            builder.Services.AddSingleton(sp =>
                new OpenAIAPI(builder.Configuration["OpenAI:ApiKey"]));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
