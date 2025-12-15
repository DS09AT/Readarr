using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.PushBullet
{
    public class PushBulletException : ShelvanceException
    {
        public PushBulletException(string message)
            : base(message)
        {
        }

        public PushBulletException(string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
        }
    }
}
