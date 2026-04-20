namespace InfoTrackApp.API.Services.Parsers;

public interface IHtmlParserFactory
{
    IHtmlParserService<TResult> GetParser<TResult>();
}