using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Update
{
    public class UpdateFailedException : ShelvanceException
    {
        public UpdateFailedException(string message, params object[] args)
            : base(message, args)
        {
        }

        public UpdateFailedException(string message)
            : base(message)
        {
        }
    }
}
