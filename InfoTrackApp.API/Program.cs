using InfoTrackApp.API.Database;
using InfoTrackApp.API.Models;
using InfoTrackApp.API.Services.Orchestrator;
using InfoTrackApp.API.Services.Parsers;
using InfoTrackApp.API.Services.Repositories;
using InfoTrackApp.API.Services.Scrapers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddHttpClient();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddHttpClient<ISolicitorScraperService, SolicitorScraperService>(client =>
{
    client.BaseAddress = new Uri("https://www.solicitors.com/");
    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
});

builder.Services.AddTransient<IHtmlParserService<SolicitorDto>, SolicitorHtmlParserService>();
builder.Services.AddTransient<IOrchestrationService, OrchestrationService>();

builder.Services.AddSingleton<IHtmlParserFactory, HtmlParserFactory>();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InfoTrackDb"));
builder.Services.AddScoped<ISolicitorRecord, SolicitorRecordRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();

using var client = new HttpClient();

// Add a User-Agent header so the site doesn't think you're a bot and block you
client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

app.Run();