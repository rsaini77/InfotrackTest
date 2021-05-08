using Xunit;
using infotrack_coding_test.extensions;

namespace infotrack_coding_tests.tests {
    public class SearchServiceTests {
        [Theory]
        [InlineData(new string[]{ "keyword1", "keyword2"}, "keyword1+keyword2")]
        [InlineData(new string[]{}, "")]
        public void ToSearchStringTest(string[] keywords, string expectedResult){
            var searchString = keywords.ToSearchString();

            Assert.Equal(expectedResult, searchString);
        }
    }
}