using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using infotrack_coding_test.services.interfaces;
using infotrack_coding_test.extensions;
using infotrack_coding_test.Controllers;
using infotrack_coding_test.Models;
using infotrack_coding_test.dto;

namespace infotrack_coding_tests.tests {
    public class SearchControllerTests {
        [Fact]
        public void GETSearchTest()
        {
            var mockSearchService = new Mock<ISearchService>();

            var controller = new SearchController(mockSearchService.Object);

            var result = controller.Search();

            var resultType = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<SearchViewModel>(resultType.ViewData.Model);
        }
        [Fact]
        public async Task POSTSearchTest_ValidModel()
        {
            var mockSearchService = new Mock<ISearchService>();
            var searchViewModel = new SearchViewModel()
            {
                Keywords = "word1 word2",
                SearchUrl = "www.test.com.au",
                SearchEngineType = "Google"
            };

            var controller = new SearchController(mockSearchService.Object);

            mockSearchService.Setup(mock => mock.Search(It.IsAny<string>(), It.IsAny<string[]>(), It.IsAny<string>()))
                .ReturnsAsync(new SearchResultDTO()
                {
                    SearchPositions = new List<int>()
                    {
                        0
                    }
                });

            var result = await controller.Search(searchViewModel);

            var resultType = Assert.IsType<ViewResult>(result);
            var resultViewModel = Assert.IsAssignableFrom<ResultsViewModel>(resultType.ViewData.Model);

            Assert.Equal(searchViewModel.SearchUrl, resultViewModel.SearchUrl);
            Assert.Equal(searchViewModel.Keywords, resultViewModel.Keywords);
            Assert.Equal(new List<int>(){
                0
            }, resultViewModel.SearchPositions);
        }
        [Fact]
        public async Task POSTSearchTest_InvalidModel()
        {
            var mockSearchService = new Mock<ISearchService>();
            var searchViewModel = new SearchViewModel()
            {
                Keywords = string.Empty,
                SearchUrl = "www.test.com.au"
            };

            var controller = new SearchController(mockSearchService.Object);

            controller.ModelState.AddModelError("keywords", "Required");

            var result = await controller.Search(searchViewModel);

            var resultType = Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<SearchViewModel>(resultType.ViewData.Model);
        }
    }
}