using System;
using Shelvance.Core.Indexers;
using Shelvance.Core.Validation;

namespace Shelvance.Core.Test.IndexerTests
{
    public class TestIndexerSettings : IIndexerSettings
    {
        public ShelvanceValidationResult Validate()
        {
            throw new NotImplementedException();
        }

        public string BaseUrl { get; set; }
        public int? EarlyReleaseLimit { get; set; }
    }
}
