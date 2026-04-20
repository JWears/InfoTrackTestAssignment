namespace InfoTrackApp.API.Models;

public record SolicitorDto(
    string Title,
    string? Address,
    string? Phone,
    string? Website,
    double? Rating, 
    int? NumberOfReviews
);