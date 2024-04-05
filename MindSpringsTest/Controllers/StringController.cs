using Microsoft.AspNetCore.Mvc;
using MindSpringsTest.Models.ViewModels;
using MindSpringsTest.Services.IServices;

namespace MindSpringsTest.Controllers
{

    public class StringController : Controller
    {
        private readonly IStringTranslatorService _stringTranslatorService;
        public StringController(IStringTranslatorService stringTranslatorService)
        {
            _stringTranslatorService = stringTranslatorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(StringTextCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _stringTranslatorService.SendStringAsync(model);
                return View(model);
            }

            return RedirectToAction("index");
        }
    }
}
