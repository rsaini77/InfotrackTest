using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infotrack_coding_test.Strategy
{
    public interface ISearchEngineStrategy
    {
        string Name { get; }
        List<int> FindSearchIndexes();
    }
}
