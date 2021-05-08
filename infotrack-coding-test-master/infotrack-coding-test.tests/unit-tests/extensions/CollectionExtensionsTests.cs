using Xunit;
using System.Collections.Generic;
using infotrack_coding_test.extensions;

namespace infotrack_coding_tests.tests {
    public class CollectionExtensionsTests {
        [Fact]
        public void FindAllIndicesTest_OneInstance(){
            var searchResults = new List<string>{ "keyword1", "keyword2"};
            var searchTerm = "keyword2";

            var searchPositions = searchResults.FindAllIndices(searchTerm);

            Assert.Contains(2, searchPositions);
        }
        [Fact]
        public void FindAllIndicesTest_MultipleInstances(){
            var searchResults = new List<string>{ "keyword1", "keyword2","keyword1","keyword4","keyword1"};
            var searchTerm = "keyword1";

            var searchPositions = searchResults.FindAllIndices(searchTerm);

            Assert.Contains(1, searchPositions);
            Assert.Contains(3, searchPositions);
            Assert.Contains(5, searchPositions);
        }
        [Fact]
        public void FindAllIndicesTest_NoInstances(){
            var searchResults = new List<string>{ "keyword1", "keyword2","keyword1","keyword4","keyword1"};
            var searchTerm = "keyword12";

            var searchPositions = searchResults.FindAllIndices(searchTerm);

            Assert.Empty(searchPositions);
        }
    }
}