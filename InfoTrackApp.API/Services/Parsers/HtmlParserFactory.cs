namespace InfoTrackApp.API.Services.Parsers;

public class HtmlParserFactory(IServiceProvider serviceProvider) : IHtmlParserFactory
{
    public IHtmlParserService<TResult> GetParser<TResult>()
    {
        var parser = serviceProvider.GetService<IHtmlParserService<TResult>>();
        
        return parser ?? throw new InvalidOperationException($"No parser registered for type {typeof(TResult).Name}");
    }
}