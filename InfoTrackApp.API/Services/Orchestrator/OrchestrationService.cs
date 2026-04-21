using InfoTrackApp.API.Database;
using InfoTrackApp.API.Models;
using InfoTrackApp.API.Services.Parsers;
using InfoTrackApp.API.Services.Repositories;
using InfoTrackApp.API.Services.Scrapers;

namespace InfoTrackApp.API.Services.Orchestrator;

public class OrchestrationService(
    ISolicitorScraperService solicitorScraperService,
    IHtmlParserFactory parserFactory,
    ISolicitorRecord repository) : IOrchestrationService
{
    public async Task<List<SolicitorDto>> GetSolicitorDetails(string practiceArea, string location)
    {
        var existingRecords = await repository.GetAllAsync();
        var matchingRecords = existingRecords
            .Where(r => r.PracticeArea == practiceArea && r.Location == location)
            .ToList();

        if (matchingRecords.Count > 0)
            return MapCachedResults(matchingRecords);

        var html = await solicitorScraperService.GetSolicitorDetails(practiceArea, location);
        var parser = parserFactory.GetParser<SolicitorDto>();
        var dto = parser.ParseHtml(html);

        await repository.SaveSearchResultsAsync(practiceArea, location, dto);

        return dto;
    }

    private static List<SolicitorDto> MapCachedResults(List<SearchRecord> records) =>
        records.Select(searchRecord => new SolicitorDto(searchRecord.Title, searchRecord.Address, searchRecord.Phone, searchRecord.Website, searchRecord.Rating, searchRecord.NumberOfReviews)).ToList();
}
