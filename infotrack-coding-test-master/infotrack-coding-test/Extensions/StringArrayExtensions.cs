namespace infotrack_coding_test.extensions
{    
    public static class StringArrayExtensions{
        public static string ToSearchString(this string[] keywords){
            string searchString = string.Empty;

            foreach(var keyword in keywords){
                if(searchString.Length == 0){
                    searchString = keyword;
                }
                else 
                {
                    searchString += $"+{keyword}";
                }
            }

            return searchString;
        }
    }
}