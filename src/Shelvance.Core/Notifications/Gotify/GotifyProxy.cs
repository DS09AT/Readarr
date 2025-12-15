using System.Net;
using Shelvance.Common.Http;

namespace Shelvance.Core.Notifications.Gotify
{
    public interface IGotifyProxy
    {
        void SendNotification(string title, string message, GotifySettings settings);
    }

    public class GotifyProxy : IGotifyProxy
    {
        private readonly IHttpClient _httpClient;

        public GotifyProxy(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void SendNotification(string title, string message, GotifySettings settings)
        {
            try
            {
                var request = new HttpRequestBuilder(settings.Server).Resource("message").Post()
                .AddQueryParam("token", settings.AppToken)
                .AddFormParameter("title", title)
                .AddFormParameter("message", message)
                .AddFormParameter("priority", settings.Priority)
                .Build();

                _httpClient.Execute(request);
            }
            catch (HttpException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new GotifyException("Unauthorized - AuthToken is invalid");
                }

                throw new GotifyException("Unable to connect to Gotify. Status Code: {0}", ex);
            }
        }
    }
}
