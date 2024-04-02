using Microsoft.AspNetCore.Mvc;

namespace MindSpringsTest.Controllers
{

    public class StringController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
