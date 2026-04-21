using System.Text.RegularExpressions;
using InfoTrackApp.API.Models;

namespace InfoTrackApp.API.Services.Parsers;

public class SolicitorHtmlParserService : IHtmlParserService<SolicitorDto>
{
    public List<SolicitorDto> ParseHtml(string html)
    {
        const string largeItemPattern = """<div class="result-item">(.*?)</ul>\s*</div>""";

        const string smallItemPattern = """<div class="result-item item-small">(.*?)</[pa]>\s*</div>""";

        var largeMatches = Regex.Matches(html, largeItemPattern, RegexOptions.Singleline);
        var smallMatches = Regex.Matches(html, smallItemPattern, RegexOptions.Singleline);

        return largeMatches
            .Concat(smallMatches)
            .Select(match => ParseBlock(match.Value))
            .ToList();
    }

    private static SolicitorDto ParseBlock(string block)
    {
        return new SolicitorDto(
            Title: ExtractTitle(block),
            Address: ExtractAddress(block),
            Phone: ExtractPhone(block),
            Website: ExtractWebsite(block),
            Rating: ExtractRating(block),
            NumberOfReviews: ExtractReviewCount(block)
        );
    }

    private static string ExtractTitle(string block)
    {
        var match = Regex.Match(block, """<span class="h2">([^<]+)""");
        return match.Success ? match.Groups[1].Value.Trim() : "";
    }

    private static string? ExtractAddress(string block)
    {
        var match = Regex.Match(block, "<address>([^<]+)</address>");
        return match.Success ? match.Groups[1].Value.Trim().Replace("&nbsp;", " ") : null;
    }

    private static string? ExtractPhone(string block)
    {
        var match = Regex.Match(block, """
                                       href="tel:([^"]+)"
                                       """);
        return match.Success ? match.Groups[1].Value.Trim() : null;
    }

    private static string? ExtractWebsite(string block)
    {
        var match = Regex.Match(block, """
                                       <a[^>]*href="(https?://[^"]+)"[^>]*rel="nofollow"
                                       """);
        return match.Success ? match.Groups[1].Value.Trim() : null;
    }

    private static double? ExtractRating(string block)
    {
        var fullStarMatches = Regex.Matches(block, """<div class="star-full[^"]*">""");
        var fullStars = fullStarMatches.Count;

        var halfStarMatches = Regex.Matches(block, """<div class="star-half[^"]*">""");
        var halfStars = halfStarMatches.Count;

        if (fullStars == 0 && halfStars == 0)
        {
            return null;
        }

        return fullStars + (halfStars * 0.5);
    }

    private static int? ExtractReviewCount(string block)
    {
        var match = Regex.Match(block, @"\((\d+)\)");
        return match.Success ? int.Parse(match.Groups[1].Value) : null;
    }
}