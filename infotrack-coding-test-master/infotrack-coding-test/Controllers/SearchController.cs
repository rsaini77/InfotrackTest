using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using infotrack_coding_test.Models;
using infotrack_coding_test.services.interfaces;

namespace infotrack_coding_test.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("")]
        public IActionResult Search()
        {
            return View(new SearchViewModel());
        }

        [HttpPost("")]
        public async Task<IActionResult> Search([FromForm]SearchViewModel searchViewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(searchViewModel);
            }
            var searchKeywords = searchViewModel.Keywords.Split(" ");

            var searchresults = await _searchService.Search(searchViewModel.SearchUrl, searchKeywords, searchViewModel.SearchEngineType);

            var results = new ResultsViewModel
            {
                SearchPositions = searchresults.SearchPositions,
                Keywords = searchViewModel.Keywords,
                SearchUrl = searchViewModel.SearchUrl
            };

            return View("~/Views/Search/Results.cshtml", results);
        }
    }
}