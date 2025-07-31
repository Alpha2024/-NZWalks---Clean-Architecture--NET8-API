using NZWalks.Web.Core.Enums;

namespace NZWalks.Web.Core.ExternalEndpoint
{
    public interface IHttpService
    {
        Task<HttpResponseMessage> MakeApiRequest(HttpVerb httpVerb, string endPoint, string serializedObject = "", Dictionary<string, string>? headers = null);
    }
}
