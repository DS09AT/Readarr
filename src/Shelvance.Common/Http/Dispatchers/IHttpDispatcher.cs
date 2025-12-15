using System.Net;
using System.Threading.Tasks;

namespace Shelvance.Common.Http.Dispatchers
{
    public interface IHttpDispatcher
    {
        Task<HttpResponse> GetResponseAsync(HttpRequest request, CookieContainer cookies);
    }
}
