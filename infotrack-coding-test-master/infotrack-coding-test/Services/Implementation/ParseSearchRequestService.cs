using HtmlAgilityPack;
using infotrack_coding_test.Services.Interfaces;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infotrack_coding_test.Services
{
    public class ParseSearchRequestService : IParseSearchRequestService
    {
        const string strToFind = @"https://www.infotrack.com.au";
        public List<int> ParseHtml(string html, int pageNum, string selectNodes)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var nodes = htmlDoc.DocumentNode.SelectNodes(selectNodes);
            var indexes = nodes == null
                  ? new List<int> { 0 }
                  : nodes.Select((x, i) => new { i, x.InnerHtml })
                        .Where(x => x.InnerHtml.Contains(strToFind))
                        .Select(x => x.i + 1 + pageNum)
                        .ToList();
            return indexes;
        }
    }
}
