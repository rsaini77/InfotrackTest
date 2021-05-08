using System.Collections.Generic;
using System;

namespace infotrack_coding_test.extensions
{    public static class CollectionExtensions{
        public static ICollection<int> FindAllIndices(this ICollection<string> stringList, string searchTerm){
            ICollection<int> positions = new List<int>();
            var position = 0;

            foreach(var item in stringList){
                if(item.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)){
                    positions.Add(position + 1);
                }
                position++;
            }
            return positions;
        }
    }
}