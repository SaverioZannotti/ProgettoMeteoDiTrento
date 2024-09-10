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

        // Metodo per configurare i servizi necessari all'applicazione
        private static void ConfigureServices(IServiceCollection services)
        {
            // Aggiunge il supporto per i controller e le viste MVC
            services.AddControllersWithViews();
        }

        // Metodo per configurare il middleware dell'applicazione
        private static void ConfigureMiddleware(WebApplication app)
        {
            // Se l'applicazione non è in modalità di sviluppo, utilizza un gestore di eccezioni
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Abilita i file statici (es. immagini, CSS, JS)
            app.UseStaticFiles();

            // Abilita il routing, che consente di mappare le richieste HTTP a specifici controller
            app.UseRouting();

            // Abilita l'autorizzazione, ma qui non ci sono specifiche regole di autenticazione impostate
            app.UseAuthorization();

            // Configura la rotta predefinita per i controller
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Configura una rotta specifica per le previsioni meteo di Trento
            app.MapControllerRoute(
                name: "MeteoTrentoPrevisioni",
                pattern: "{controller=MeteoTrento}/{action=LetturaPrevisioni}/{id?}");
        }
    }
}
