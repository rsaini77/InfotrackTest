using System.Threading.Tasks;
using System.Collections.Generic;

namespace infotrack_coding_test.services.interfaces
{
    public interface IParseSearchResponseService
    {
        Task<ICollection<string>> ParseResponseBody(string responseBody);
    }
}
