namespace InfoTrackApp.API.Database;

public class SearchRecord
{
    public int Id { get; set; }
    public required string PracticeArea { get; set; }
    public required string Location { get; set; }
    public required string Title { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public string? Website { get; set; }
    public double? Rating { get; set; }
    public int? NumberOfReviews { get; set; }
    public DateTime SearchedAt { get; set; } = DateTime.UtcNow;
}