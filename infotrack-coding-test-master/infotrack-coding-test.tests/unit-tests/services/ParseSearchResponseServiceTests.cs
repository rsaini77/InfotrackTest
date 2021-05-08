using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using infotrack_coding_test.extensions;
using infotrack_coding_test.services;

namespace infotrack_coding_tests.tests {
    public class ParseSearchResponseServiceTests 
    {
        [Fact]
        public async Task ParseResponseBodyTest_NoResponseBody(){
            var parseResponseBodyService = new ParseSearchResponseService();

            var responseBody = string.Empty; 
            var expectedResult = new List<string>();

            var parsedResponse = await parseResponseBodyService.ParseResponseBody(responseBody);

            Assert.Equal(expectedResult, parsedResponse);
        }
        [Fact]
        public async Task ParseResponseBodyTest_SingleItemInResponseBody(){
            var parseResponseBodyService = new ParseSearchResponseService();

            var responseBody = "<div><cite>https://www.somewebsite.com.au</cite></div>"; 
            var expectedResult = new List<string>(){
                "<cite>https://www.somewebsite.com.au</cite>"
            };

            var parsedResponse = await parseResponseBodyService.ParseResponseBody(responseBody);

            Assert.Equal(expectedResult, parsedResponse);
        }
        [Fact]
        public async Task ParseResponseBodyTest_MultipleItemsInResponseBody(){
            var parseResponseBodyService = new ParseSearchResponseService();

            var responseBody = "<div><cite>https://www.somewebsite.com.au</cite></div><div><cite>https://www.somewebsite2.com.au</cite></div>"; 
            var expectedResult = new List<string>()
            {
                "<cite>https://www.somewebsite.com.au</cite>",
                "<cite>https://www.somewebsite2.com.au</cite>"
            };

            var parsedResponse = await parseResponseBodyService.ParseResponseBody(responseBody);

            Assert.Equal(expectedResult, parsedResponse);
        }
        [Fact]
        public async Task ParseResponseBodyTest_NoMatchingItemsInResponseBody(){
            var parseResponseBodyService = new ParseSearchResponseService();

            var responseBody = "<div><span>some html data</span></div>"; 
            var expectedResult = new List<string>();

            var parsedResponse = await parseResponseBodyService.ParseResponseBody(responseBody);

            Assert.Equal(expectedResult, parsedResponse);
        }
    }
}