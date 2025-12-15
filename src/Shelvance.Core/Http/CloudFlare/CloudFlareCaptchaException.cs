using Shelvance.Common.Exceptions;
using Shelvance.Common.Http;

namespace Shelvance.Core.Http.CloudFlare
{
    public class CloudFlareCaptchaException : ShelvanceException
    {
        public HttpResponse Response { get; set; }

        public CloudFlareCaptchaRequest CaptchaRequest { get; set; }

        public CloudFlareCaptchaException(HttpResponse response, CloudFlareCaptchaRequest captchaRequest)
            : base("Unable to access {0}, blocked by CloudFlare CAPTCHA. Likely due to shared-IP VPN.", response.Request.Url.Host)
        {
            Response = response;
            CaptchaRequest = captchaRequest;
        }

        public bool IsExpired => Response.Request.Cookies.ContainsKey("cf_clearance");
    }
}
