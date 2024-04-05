using MindSpringsTest.Extensions;
using MindSpringsTest.Models.Data;
using MindSpringsTest.Models.ViewModels;
using MindSpringsTest.Services.IServices;
using Newtonsoft.Json;
using RestSharp;

namespace MindSpringsTest.Services
{
    public class StringTranslatorService : IStringTranslatorService
    {
        private readonly AppIdentityDbContext _appIdentityDbContext;
        private readonly RestExtension _restExtension;
        private readonly TranslatorSettings _translatorSettings;

        public StringTranslatorService(AppIdentityDbContext appIdentityDbContext, RestExtension restExtension, TranslatorSettings translatorSettings)
        {
            _appIdentityDbContext = appIdentityDbContext;
            _restExtension = restExtension;
            _translatorSettings = translatorSettings;
        }

        public async Task<Models.ViewModels.StringTextGetViewModel> SendStringAsync(StringTextCreateViewModel viewModel)
        {
            try
            {
                dynamic model = new
                {
                    TextToTranslate = viewModel.TextToTranslate,
                };

                RestModel restModel = new RestModel
                {
                    BaseUrl = _translatorSettings.FunTranslationBaseUrl,
                    ApiResource = _translatorSettings.YodaApiResource,
                    RequestMethod = Method.Post,
                    RequestBody = model,
                };

                var response = await _restExtension.ExecuteAsync(restModel);
                if (!response.IsSuccessful)
                    return null;

                var responseViewModel = JsonConvert.DeserializeObject<StringTextGetViewModel>(response.Content);

                return responseViewModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }

            return new StringTextGetViewModel();
        }
    }
}
