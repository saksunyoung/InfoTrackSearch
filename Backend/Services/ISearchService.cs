using InfoTrackSearch.Models;

namespace InfoTrackSearch.Services;

public interface ISearchService
{
    Task<SearchResponse> GetRankingsAsync(SearchRequest request);
}
