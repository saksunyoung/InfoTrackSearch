namespace InfoTrackSearch.Models;

public class SearchResponse(List<int> rankings, List<string> resultUrls)
{
    public List<int> Rankings { get; set; } = rankings;
    public List<string> ResultUrls { get; set; } = resultUrls;
    public bool IsFound { get; set; } = rankings.Count > 0;
}
