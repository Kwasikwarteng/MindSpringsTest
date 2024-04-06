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

        [HttpPost]
        public async Task<IActionResult> Create(StringTextGetViewModel model)
        {
            var translationResponse = await _stringTranslatorService.SendStringAsync(model);

            if (translationResponse != null)
            {
                // Redirect to a different action method upon successful API call
                return RedirectToAction("GridList", translationResponse);
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to translate the text.";
                return View("Index");
            }
        }

        public IActionResult GridList(TranslatorResponseViewModel viewModel)
        {
            //ViewBag.TranslatedText = translatedText;
            return View(viewModel);
        }
    }
}
