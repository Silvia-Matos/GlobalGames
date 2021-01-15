namespace GlobalGames.Controllers
{
    using System.Diagnostics;
    using Models;
    using Microsoft.AspNetCore.Mvc;
    

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sobre()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Inscricao()
        {
            return View();
        }

        public IActionResult Servicos()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
