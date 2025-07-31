using NZWalks.Web.Core.Enums;
using System.Text;

namespace NZWalks.Web.Core.ExternalEndpoint
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HttpService> _logger;

        public HttpService(IHttpClientFactory httpClientFactory, ILogger<HttpService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<HttpResponseMessage> MakeApiRequest(HttpVerb httpVerb, string endPoint, string serializedObject = "", Dictionary<string, string>? headers = null)
        {
            try
            {
                var client = _httpClientFactory.CreateClient("NZWalks");
                HttpResponseMessage response = new HttpResponseMessage();
                StringContent content = new StringContent(serializedObject, Encoding.UTF8, "application/json");

                if (headers is not null)
                {
                    foreach (var header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }

                switch (httpVerb)
                {
                    case HttpVerb.GET:
                        response = await client.GetAsync(endPoint);
                        break;
                    case HttpVerb.POST:
                        response = await client.PostAsync(endPoint, content);
                        break;
                    case HttpVerb.PUT:
                        response = await client.PutAsync(endPoint, content);
                        break;
                    case HttpVerb.DELETE:
                        response = await client.DeleteAsync(endPoint);
                        break;
                    default:
                        break;
                }

                return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Error", ex);
            }
        }
    }
}
