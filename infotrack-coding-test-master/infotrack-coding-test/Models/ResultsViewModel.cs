using System;
using System.Collections.Generic;

namespace infotrack_coding_test.Models
{
    public class ResultsViewModel : SearchViewModel
    {
        public ICollection<int> SearchPositions { get; set; }
    }
}