using infotrack_coding_test.services.interfaces;
using infotrack_coding_test.Services.Interfaces;
using infotrack_coding_test.Strategy.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infotrack_coding_test.Strategy.Context
{
    public class StrategyContext
    {
        string searchEngineType;
        Dictionary<string, ISearchEngineStrategy> strategyContext
            = new Dictionary<string, ISearchEngineStrategy>();
        public StrategyContext(string searchEngineType, IParseSearchRequestService parseSearchRequestService, IParseSearchResponseService parseSearchResponseService, IHttpService httpService)
        {
            this.searchEngineType = searchEngineType;
            strategyContext.Add(nameof(GoogleSearchEngineStrategy),
                    new GoogleSearchEngineStrategy(parseSearchRequestService, parseSearchResponseService, httpService));
            strategyContext.Add(nameof(BingSearchEngineStrategy),
                    new BingSearchEngineStrategy(parseSearchRequestService, parseSearchResponseService, httpService));
        }

        public List<int> ApplyStrategy(ISearchEngineStrategy strategy)
        {
            return strategy.FindSearchIndexes();
        }

        public ISearchEngineStrategy GetStrategy(string searchEngineType)
        {
            ISearchEngineStrategy strategy = strategyContext[nameof(GoogleSearchEngineStrategy)];
            switch (searchEngineType)
            {
                case "Google":
                    strategy = strategyContext[nameof(GoogleSearchEngineStrategy)];
                    break;
                case "Bing":
                    strategy = strategyContext[nameof(BingSearchEngineStrategy)];
                    break;
                default:
                    strategy = strategyContext[nameof(GoogleSearchEngineStrategy)];
                    break;
            }
            return strategy;
        }
    }
}
