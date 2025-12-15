using System;
using Shelvance.Common.Exceptions;

namespace Shelvance.Core.Notifications.Slack
{
    public class SlackExeption : ShelvanceException
    {
        public SlackExeption(string message)
            : base(message)
        {
        }

        public SlackExeption(string message, Exception innerException, params object[] args)
            : base(message, innerException, args)
        {
        }
    }
}
