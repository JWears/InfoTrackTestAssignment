using InfoTrackApp.API.Database;
using InfoTrackApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace InfoTrackApp.API.Services.Repositories;

public class SolicitorRecordRepository(AppDbContext dbContext) : ISolicitorRecord
{
    public async Task SaveSearchResultsAsync(string practiceArea, string location, List<SolicitorDto> results)
    {
        ArgumentNullException.ThrowIfNull(practiceArea);
        ArgumentNullException.ThrowIfNull(location);
        ArgumentNullException.ThrowIfNull(results);
        if (results.Count == 0) return;
        
        var records = results.Select(dto => new SearchRecord
        {
            PracticeArea = practiceArea,
            Location = location,
            Title = dto.Title,
            Address = dto.Address,
            Phone = dto.Phone,
            Website = dto.Website,
            Rating = dto.Rating,
            NumberOfReviews = dto.NumberOfReviews
        });

        dbContext.SearchRecords.AddRange(records);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<SearchRecord>> GetAllAsync() =>
        await dbContext.SearchRecords.ToListAsync();
}
