using infotrack_coding_test.services.interfaces;
using infotrack_coding_test.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace infotrack_coding_test.Strategy.Implementation
{
    public class BingSearchEngineStrategy : ISearchEngineStrategy
    {
        private readonly IParseSearchRequestService _parseSearchRequestService;
        private readonly IParseSearchResponseService _parseSearchResponseService;
        private readonly IHttpService _httpService;
        public string Name => nameof(BingSearchEngineStrategy);
        private const string selectNodes = @"//html//body//li[@class='b_algo']";
        public BingSearchEngineStrategy(IParseSearchRequestService parseSearchRequestService, IParseSearchResponseService parseSearchResponseService, IHttpService httpService)
        {
            _parseSearchRequestService = parseSearchRequestService;
            _parseSearchResponseService = parseSearchResponseService;
            _httpService = httpService;
        }
        // The test gives the static pages
        // otherwise it would have been good to use https://www.bing.com/search?q=online+title+search&count=50
        List<string> listOfUrls = new System.Collections.Generic.List<string>
        {
            "https://infotrack-tests.infotrack.com.au/Bing/Page01.html",
            "https://infotrack-tests.infotrack.com.au/Bing/Page02.html",
            "https://infotrack-tests.infotrack.com.au/Bing/Page03.html",
            "https://infotrack-tests.infotrack.com.au/Bing/Page04.html",
            "https://infotrack-tests.infotrack.com.au/Bing/Page05.html"
        };
        
        public List<int> FindSearchIndexes()
        {
            int pageNum = 0;
            List<int> linkList = new List<int>();
            foreach (var url in listOfUrls)
            {
                var response = _httpService.CallUrl(url).Result;
                var list = _parseSearchRequestService.ParseHtml(response, pageNum, selectNodes);
                linkList = linkList.Concat(list).ToList();
                pageNum = pageNum + 10;
            }
            return linkList;
        }
    }
}
