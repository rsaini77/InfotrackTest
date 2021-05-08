using System.Threading.Tasks;
using infotrack_coding_test.dto;

namespace infotrack_coding_test.services.interfaces
{
    public interface ISearchService
    {
        //Task<SearchResultDTO> Search(string searchUrl, string[] keywords);
        Task<SearchResultDTO> Search(string searchUrl, string[] keywords, string searchEngineType);
    }
}