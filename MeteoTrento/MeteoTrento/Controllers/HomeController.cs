using Microsoft.AspNetCore.Mvc;  // Namespace per utilizzare i controller MVC in ASP.NET Core.
using MeteoTrento.Models;       // Namespace per accedere ai modelli utilizzati nell'applicazione.
using System.Diagnostics;       // Namespace per il debug e la gestione delle attività.

namespace MeteoTrento.Controllers
{
    // Il controller principale dell'applicazione che gestisce le richieste per la home page e altre pagine generiche.
    public class HomeController : Controller
    {
        // Campo di sola lettura per il logger, utilizzato per registrare informazioni di log per il controller.
        private readonly ILogger<HomeController> _logger;

        // Costruttore del controller che riceve un'istanza di ILogger tramite dependency injection.
        public HomeController(ILogger<HomeController> logger)
        {
            // Inizializza il logger o solleva un'eccezione se è nullo.
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // Metodo di azione che gestisce le richieste GET per la vista Index.
        public IActionResult Index()
        {
            // Restituisce la vista predefinita associata a questa azione ("Index.cshtml").
            return View();
        }

        // Metodo di azione che gestisce le richieste GET per la vista Privacy.
        public IActionResult Privacy()
        {
            // Restituisce la vista predefinita associata a questa azione ("Privacy.cshtml").
            return View();
        }

        // Metodo di azione che gestisce le richieste per la vista di errore e fornisce una cache personalizzata per la risposta.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Ottiene l'identificativo della richiesta corrente o l'identificatore di traccia HTTP se non disponibile.
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            // Crea un modello di vista di errore con l'ID della richiesta corrente.
            var errorViewModel = new ErrorViewModel { RequestId = requestId };

            // Restituisce la vista di errore popolata con il modello di errore.
            return View(errorViewModel);
        }
    }
}
