using InfoTrackApp.API.Database;
using InfoTrackApp.API.Models;

namespace InfoTrackApp.API.Services.Repositories;

public interface ISolicitorRecord
{
    Task SaveSearchResultsAsync(string practiceArea, string location, List<SolicitorDto> results);
    Task<List<SearchRecord>> GetAllAsync();
}