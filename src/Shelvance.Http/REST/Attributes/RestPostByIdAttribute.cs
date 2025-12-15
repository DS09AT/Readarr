using System;
using Microsoft.AspNetCore.Mvc;

namespace Shelvance.Http.REST.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RestPostByIdAttribute : HttpPostAttribute
    {
    }
}
