namespace InfoTrackApp.API.Services.Parsers;

public interface IHtmlParserService<TResult>
{
    List<TResult> ParseHtml(string html);
}