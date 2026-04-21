using InfoTrackApp.API.Models;
using InfoTrackApp.API.Services.Orchestrator;
using Microsoft.AspNetCore.Mvc;

namespace InfoTrackApp.API.Controllers;

[ApiController]
[Route("[controller]")]
public class SolicitorSearchController(IOrchestrationService orchestrationService) : ControllerBase
{
    [HttpGet("GetSolicitorData")]
    [Produces("application/json")]
    public async Task<List<SolicitorDto>> GetSolicitorData([FromQuery] string practiceArea, [FromQuery] string location)
    {
        var result = await orchestrationService.GetSolicitorDetails(practiceArea, location);
        return result;
    }
}