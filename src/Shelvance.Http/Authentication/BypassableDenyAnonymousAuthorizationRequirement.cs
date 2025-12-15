using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Shelvance.Http.Authentication
{
    public class BypassableDenyAnonymousAuthorizationRequirement : DenyAnonymousAuthorizationRequirement
    {
    }
}
