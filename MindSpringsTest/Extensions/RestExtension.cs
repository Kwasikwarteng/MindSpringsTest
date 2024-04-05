using Microsoft.Extensions.Options;
using RestSharp;

namespace MindSpringsTest.Extensions
{
    public class RestModel
    {
        public string BaseUrl { get; set; }
        public string ApiResource { get; set; }
        public Method RequestMethod { get; set; }
        public List<KeyValuePair<string, string>> Parameters { get; set; }
        public List<KeyValuePair<string, string>> Headers { get; set; }
        public List<KeyValuePair<string, string>> UrlSegments { get; set; }
        public object RequestBody { get; set; }
    }

    public class RestExtension
    {
        public async Task<RestResponse> ExecuteAsync(RestModel model)
        {
            var options = new RestClientOptions(model.BaseUrl)
            {
                MaxTimeout = 120000
            };
            RestClient restClient = new RestClient(options);

            var request = new RestRequest(model.ApiResource, model.RequestMethod);
            request.AddHeader("Cache-Control", "no-cache");
            //not necessary
            request.AddHeader("Content-Type", "application/json");

            //loop through assign urlSegments
            model.UrlSegments?.ForEach(s => { request.AddUrlSegment(s.Key, s.Value); });

            //loop through assign headers
            model.Headers?.ForEach(h => { request.AddHeader(h.Key, h.Value); });

            //loop through assign parameters
            model.Parameters?.ForEach(p => { request.AddParameter(p.Key, p.Value); });

            if (model.RequestBody is not null)
                request.AddJsonBody(model.RequestBody);

            RestResponse restResponse = await restClient.ExecuteAsync(request);

            return restResponse;
        }
    }

    public class SendTextToTranslate
    {
        private readonly RestExtension _restExtension;
        private readonly IOptions<TranslatorSettings> _options;
        public SendTextToTranslate(RestExtension restExtension, IOptions<TranslatorSettings> options)
        {
            _restExtension = restExtension;
            _options = options;
        }

        private async Task Send()
        {

        }
    }

}
