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

string url = "https://www.solicitors.com/conveyancing+london.html";
string html = await client.GetStringAsync(url);

Console.WriteLine(html);

app.MapGet("GetLegalClientsLondon", () => html);

app.Run();