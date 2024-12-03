using InfoTrackSearch.Models;
using InfoTrackSearch.Services;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrackSearch.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController(ISearchService searchService) : ControllerBase
{
    private readonly ISearchService _searchService = searchService;

    [HttpPost]
    public async Task<IActionResult> Search([FromBody] SearchRequest request)
    {
        if (string.IsNullOrEmpty(request.Keywords) || string.IsNullOrEmpty(request.UrlToFind))
        {
            return BadRequest("Keyword or URL cannot be empty.");
        }
        SearchResponse result = await _searchService.GetRankingsAsync(request);
        return Ok(result);
    }
}
