using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infotrack_coding_test.Services.Interfaces
{
    public interface IParseSearchRequestService
    {
        List<int> ParseHtml(string html, int pageNum, string selectNodes);
    }
}
