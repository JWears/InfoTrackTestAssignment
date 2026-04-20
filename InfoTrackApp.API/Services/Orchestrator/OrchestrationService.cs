using InfoTrackApp.API.Models;
using InfoTrackApp.API.Services.Parsers;
using InfoTrackApp.API.Services.Scrapers;

namespace InfoTrackApp.API.Services.Orchestrator;

public class OrchestrationService(ISolicitorScraperService solicitorScraperService, IHtmlParserFactory parserFactory) : IOrchestrationService
{
    public async Task<List<SolicitorDto>> GetSolicitorDetails(string practiceArea, string location)
    {
        var html = await solicitorScraperService.GetSolicitorDetails(practiceArea, location);
        var parser = parserFactory.GetParser<SolicitorDto>();
        var dto = parser.ParseHtml(html);
        
        return dto;
    }
}