using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Kavita;

public class KavitaException : ShelvanceException
{
    public KavitaException(string message)
        : base(message)
    {
    }

    public KavitaException(string message, params object[] args)
        : base(message, args)
    {
    }
}
