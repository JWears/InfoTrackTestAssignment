namespace InfoTrackApp.API.Services.Scrapers;

public interface ISolicitorScraperService
{
    Task<string> GetSolicitorDetails(string practiceArea, string location);
}