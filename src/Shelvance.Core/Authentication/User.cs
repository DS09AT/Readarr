using System;
using Shelvance.Core.Datastore;

namespace Shelvance.Core.Authentication
{
    public class User : ModelBase
    {
        public Guid Identifier { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
