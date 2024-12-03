using InfoTrackSearch.Models;
using System.Text.RegularExpressions;

namespace InfoTrackSearch.Services;

public class SearchService(HttpClient httpClient) : ISearchService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<SearchResponse> GetRankingsAsync(SearchRequest request)
    {
        string url = request.BuildSearchUrl();
        string response = await _httpClient.GetStringAsync(url);
        Regex regex = new Regex(@"<a href=""/url\?q=(http[s]?://[^\""]+)", RegexOptions.IgnoreCase);
        MatchCollection matches = regex.Matches(response);

        int position = 0;
        List<int> rankings = [];
        List<string> resultUrls = [];
        if (matches.Count != 0)
        {
            foreach (Match match in matches)
            {
                string resultUrl = match.Groups[1].Value;
                if (resultUrl.Contains(request.UrlToFind))
                {
                    rankings.Add(position);
                    resultUrls.Add(resultUrl.Split("&amp").First());
                }
                position++;

                if (rankings.Count == 100)
                {
                    break;
                }
            }
        }

        return new(rankings, resultUrls);
    }
}
