using System.Diagnostics;
using Shelvance.Common.EnsureThat.Resources;

namespace Shelvance.Common.EnsureThat
{
    public static class EnsureObjectExtensions
    {
        [DebuggerStepThrough]
        public static Param<T> IsNotNull<T>(this Param<T> param)
            where T : class
        {
            if (param.Value == null)
            {
                throw ExceptionFactory.CreateForParamNullValidation(param.Name, ExceptionMessages.EnsureExtensions_IsNotNull);
            }

            return param;
        }
    }
}
