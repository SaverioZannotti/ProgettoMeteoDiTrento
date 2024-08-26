using Microsoft.AspNetCore.Mvc;
using ModelliMeteoTrento;
using MeteoTrento.ViewModels;
using ServiziMeteoTrento;

namespace MeteoTrento.Controllers
{
    public class MeteoTrentoController : Controller
    {
        public async Task<IActionResult> LetturaPrevisioni()
        {
            List<PrevisioneOutput> listaMeteo = LetturaDati.Lettura().Result;
            MeteoTrentoLetturaPrevisioniViewModel vm = new MeteoTrentoLetturaPrevisioniViewModel();
            {
                vm.lista = listaMeteo;
            };
            return View(vm);
        }
    }
}
