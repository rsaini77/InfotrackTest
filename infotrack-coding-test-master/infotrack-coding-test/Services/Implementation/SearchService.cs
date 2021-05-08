using infotrack_coding_test.dto;
using infotrack_coding_test.services.interfaces;
using infotrack_coding_test.Services.Interfaces;
using infotrack_coding_test.Strategy;
using infotrack_coding_test.Strategy.Context;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace infotrack_coding_test.services
{
    public class SearchService : ISearchService
    {
        private readonly IParseSearchRequestService _parseRequestService;
        private readonly IParseSearchResponseService _parseResponseService;
        private readonly IHttpService _httpService;


        public SearchService(IParseSearchRequestService parseRequestService, IParseSearchResponseService parseResponseService, IHttpService httpRequest)
        {
            _parseResponseService = parseResponseService;
            _parseRequestService = parseRequestService;
            _httpService = httpRequest;
        }
        public async Task<SearchResultDTO> Search(string searchUrl, string[] keywords, string searchEngineType)
        {
            try
            {
                StrategyContext context = new StrategyContext(searchEngineType, _parseRequestService, _parseResponseService, _httpService);
                ISearchEngineStrategy strategy = context.GetStrategy(searchEngineType);
                var linkList = context.ApplyStrategy(strategy);
                SearchResultDTO searchResultDto = new SearchResultDTO()
                {
                    SearchPositions = linkList
                };

                return searchResultDto;
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.Status);
            }
            return new SearchResultDTO(); ;
        }
    }
}