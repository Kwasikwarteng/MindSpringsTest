using MindSpringsTest.Models.ViewModels;

namespace MindSpringsTest.Services.IServices
{
    public interface IStringTranslatorService
    {
        Task<TranslatorResponseViewModel> SendStringAsync(StringTextGetViewModel viewModel);
    }
}
