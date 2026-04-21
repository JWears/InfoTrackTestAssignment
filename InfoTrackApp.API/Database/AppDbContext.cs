using Microsoft.EntityFrameworkCore;

namespace InfoTrackApp.API.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<SearchRecord> SearchRecords => Set<SearchRecord>();
}