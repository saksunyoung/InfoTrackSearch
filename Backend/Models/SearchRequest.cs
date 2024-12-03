namespace InfoTrackSearch.Models;

public class SearchRequest(string keywords, string urlToFind)
{
    public string Keywords { get; set; } = keywords;
    public string UrlToFind { get; set; } = urlToFind;

    public string BuildSearchUrl()
    {
        return $"https://www.google.co.uk/search?num=100&q={Uri.EscapeDataString(Keywords)}";
    }
}
