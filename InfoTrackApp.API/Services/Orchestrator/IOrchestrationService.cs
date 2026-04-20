using InfoTrackApp.API.Models;

namespace InfoTrackApp.API.Services.Orchestrator;

public interface IOrchestrationService
{
    public Task<List<SolicitorDto>> GetSolicitorDetails(string practiceArea, string location);
}