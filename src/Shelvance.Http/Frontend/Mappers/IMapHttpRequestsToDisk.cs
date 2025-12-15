using Microsoft.AspNetCore.Mvc;

namespace Shelvance.Http.Frontend.Mappers
{
    public interface IMapHttpRequestsToDisk
    {
        string Map(string resourceUrl);
        bool CanHandle(string resourceUrl);
        IActionResult GetResponse(string resourceUrl);
    }
}
