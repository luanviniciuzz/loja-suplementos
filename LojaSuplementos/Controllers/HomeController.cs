using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaSuplementos.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

     
    }
}
