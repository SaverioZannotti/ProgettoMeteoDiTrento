using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MeteoTrento
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Crea un builder per l'applicazione web
            var builder = WebApplication.CreateBuilder(args);

            // Configura i servizi dell'applicazione
            ConfigureServices(builder.Services);

            // Costruisce l'applicazione
            var app = builder.Build();

            // Configura il pipeline delle richieste HTTP
            ConfigureMiddleware(app);

            // Avvia l'applicazione
            app.Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        private static void ConfigureMiddleware(WebApplication app)
        {
            // Gestisce le eccezioni per ambienti non di sviluppo
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            // Configura le rotte dei controller
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "MeteoTrentoPrevisioni",
                pattern: "{controller=MeteoTrento}/{action=LetturaPrevisioni}/{id?}");
        }
    }
}
