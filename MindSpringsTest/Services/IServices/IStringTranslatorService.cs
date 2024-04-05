using MindSpringsTest.Models.ViewModels;

namespace MindSpringsTest.Services.IServices
{
    public interface IStringTranslatorService
    {
        Task<StringTextGetViewModel> SendStringAsync(StringTextCreateViewModel viewModel);
    }
}
