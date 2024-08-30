using Microsoft.AspNetCore.Mvc;             // Namespace per utilizzare i controller MVC in ASP.NET Core.
using ModelliMeteoTrento;                   // Namespace per accedere ai modelli utilizzati nell'applicazione.
using MeteoTrento.ViewModels;               // Namespace per accedere ai ViewModel dell'applicazione.
using ServiziMeteoTrento;                   // Namespace per accedere ai servizi utilizzati nell'applicazione.

namespace MeteoTrento.Controllers
{
    // Controller per gestire le operazioni relative alle previsioni meteo per Trento.
    public class MeteoTrentoController : Controller
    {
        // Metodo di azione asincrono che gestisce la lettura delle previsioni meteo e passa i dati alla vista.
        public async Task<IActionResult> LetturaPrevisioni()
        {
            // Esegue la lettura dei dati meteo chiamando un servizio esterno e ottiene una lista di previsioni.
            List<PrevisioneOutput> listaMeteo = LetturaDati.Lettura().Result;

            // Crea un'istanza del ViewModel per la vista di lettura previsioni.
            MeteoTrentoLetturaPrevisioniViewModel vm = new MeteoTrentoLetturaPrevisioniViewModel();
            {
                // Popola il ViewModel con la lista delle previsioni meteo ottenute.
                vm.lista = listaMeteo;
            };

            // Restituisce la vista associata al ViewModel, popolata con le previsioni meteo.
            return View(vm);
        }
    }
}
