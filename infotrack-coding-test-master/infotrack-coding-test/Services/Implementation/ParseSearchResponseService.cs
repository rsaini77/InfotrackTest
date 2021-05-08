using infotrack_coding_test.services.interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace infotrack_coding_test.services
{
    public class ParseSearchResponseService : IParseSearchResponseService
    {
        public async Task<ICollection<string>> ParseResponseBody(string responseBody){
            var regexPattern = @"(?:<cite[a-zA-Z.,""':;\\=\s\d]*>(?:<strong>)?([^|]*?)(?:<\/strong>)?<\/cite>)+";

            Regex regex = new Regex(regexPattern);

            return await Task.Run(() => regex.Matches(responseBody).Select(i => i.Value).ToList());
        }
    }
}