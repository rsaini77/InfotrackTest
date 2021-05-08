using infotrack_coding_test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace infotrack_coding_test.Services
{
    public class HttpService : IHttpService
    {
        public async Task<string> CallUrl(string fullUrl)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            var response = client.GetStringAsync(fullUrl);
            return await response;
        }
    }
}
