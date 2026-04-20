using System.Text.RegularExpressions;
using InfoTrackApp.API.Models;

namespace InfoTrackApp.API.Services.Parsers;

public class SolicitorHtmlParserService : IHtmlParserService<SolicitorDto>
{
    public List<SolicitorDto> ParseHtml(string html)
    {
        var solicitors = new List<SolicitorDto>();
        const string resultItemPattern = """<div class="result-item[^"]*">(.*?)</div>\s*</div>""";
        var resultMatches = Regex.Matches(html, resultItemPattern, RegexOptions.Singleline);
        
        foreach (Match resultMatch in resultMatches)
        {
            var block = resultMatch.Value;
            
            var title = ExtractTitle(block);
            var address = ExtractAddress(block);
            var phone = ExtractPhone(block);
            var website = ExtractWebsite(block);
            var rating = ExtractRating(block);
            var numberOfReviews = ExtractReviewCount(block);
            
            var solicitor = new SolicitorDto(
                Title: title,
                Address: address,
                Phone: phone,
                Website: website,
                Rating: rating,
                NumberOfReviews: numberOfReviews
            );
            
            solicitors.Add(solicitor);
        }
        
        return solicitors;
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