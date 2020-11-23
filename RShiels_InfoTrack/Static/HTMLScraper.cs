using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RShiels_InfoTrack.Static
{
    public class HTMLScraper
    {
        public static string GetResults(string rawHTML, string searchURL)
        {
            if (string.IsNullOrEmpty(searchURL))
                return "0";

            List<int> indexesValidURL = allIndexesOf(rawHTML, "<a href=\"/url?q=");

            List<string> results = getURLS(indexesValidURL, rawHTML);

            return getIndexOfURL(searchURL, results);
        }

        private static List<string> getURLS(List<int> indexesValidURL, string rawHTML)
        {
            List<string> returnString = new List<string>();
            foreach (int index in indexesValidURL)
            {
                int i = index;
                do
                {
                    i++;
                } while (rawHTML[i] != '>');

                returnString.Add(rawHTML.Substring(index, (i - index + 1)));
            }
            return returnString;
        }

        private static List<int> allIndexesOf(string str, string value)
        {
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        private static string getIndexOfURL(string searchURL, List<string> results)
        {
            List<int> indexMatch = new List<int>();

            foreach (string s in results)
            {
                if (s.Contains(searchURL))
                    indexMatch.Add(results.IndexOf(s) + 1);
            }

            return (indexMatch.Count == 0) ? "0" : string.Join(",", indexMatch);
        }
    }
}