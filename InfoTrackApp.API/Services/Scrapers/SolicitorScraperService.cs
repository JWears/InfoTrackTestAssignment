namespace InfoTrackApp.API.Services.Scrapers;

public class SolicitorScraperService(HttpClient httpClient) : ISolicitorScraperService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<string> GetSolicitorDetails(string practiceArea, string location)
    {
        if (string.IsNullOrEmpty(practiceArea) || string.IsNullOrEmpty(location))
        {
            return string.Empty;
        }

        var queryString = BuildQueryString(practiceArea, location);
        try
        {
            var response = await _httpClient.GetAsync(queryString);
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        catch (HttpRequestException e)
        {
            return e.Message;
        }
    }

    private static string BuildQueryString(string practiceArea, string location)
    {
        return $"{practiceArea}+{location}";
    }
}