using MindSpringsTest.Extensions;
using MindSpringsTest.Models.Data;
using MindSpringsTest.Models.ViewModels;
using MindSpringsTest.Services.IServices;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace MindSpringsTest.Services
{
    public class StringTranslatorService : IStringTranslatorService
    {
        private readonly AppIdentityDbContext _appIdentityDbContext;
        private readonly RestExtension _restExtension;
        private readonly TranslatorSettings _translatorSettings;
        private readonly RestClient _restClient;


        public StringTranslatorService(AppIdentityDbContext appIdentityDbContext, RestExtension restExtension, TranslatorSettings translatorSettings)
        {
            _appIdentityDbContext = appIdentityDbContext;
            _restExtension = restExtension;
            _translatorSettings = translatorSettings;
        }

        public async Task<TranslatorResponseViewModel> SendStringAsync(StringTextGetViewModel viewModel)
        {
            string baseUrl = "https://api.funtranslations.com/";
            var client = new RestClient(baseUrl);
            var request = new RestRequest("translate/yoda.json", Method.Post);
            request.AddJsonBody(new { text = viewModel.TextToTranslate });
            var response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseObject = JObject.Parse(response.Content);
                var contentsObject = responseObject["contents"];
                var translatedText = contentsObject["translated"].Value<string>();
                //var translatedMessage = JsonConvert.DeserializeObject<TranslatorResponseViewModel>(response.Content);

                var translatorResponse = new TranslatorResponseViewModel
                {
                    Translation = translatedText
                };

                return translatorResponse;
            }
            return new TranslatorResponseViewModel();


        }


    }
}
