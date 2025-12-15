using NLog;
using Shelvance.Common.Http;
using Shelvance.Core.Configuration;
using Shelvance.Core.Indexers;
using Shelvance.Core.Parser;

namespace Shelvance.Core.Test.IndexerTests
{
    public class TestIndexer : HttpIndexerBase<TestIndexerSettings>
    {
        public override string Name => "Test Indexer";

        public override DownloadProtocol Protocol => DownloadProtocol.Usenet;

        public int _supportedPageSize;
        public override int PageSize => _supportedPageSize;

        public TestIndexer(IHttpClient httpClient, IIndexerStatusService indexerStatusService, IConfigService configService, IParsingService parsingService, Logger logger)
            : base(httpClient, indexerStatusService, configService, parsingService, logger)
        {
        }

        public IIndexerRequestGenerator _requestGenerator;
        public override IIndexerRequestGenerator GetRequestGenerator()
        {
            return _requestGenerator;
        }

        public IParseIndexerResponse _parser;
        public override IParseIndexerResponse GetParser()
        {
            return _parser;
        }
    }
}
