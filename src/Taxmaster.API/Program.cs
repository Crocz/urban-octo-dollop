using Taxmaster.Domain;
using Microsoft.EntityFrameworkCore;
using Taxmaster.Infrastructure;
using Taxmaster.API;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Server=localhost;Port=5432;Database=initexample;User Id=initexample;Password=initexample;";

builder.Services.AddScoped<TaxService>();
builder.Services.AddScoped<IRuleRepository, RuleRepository>();
builder.Services.AddDbContext<RuleContext>(opt => opt.UseNpgsql(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseMiddleware<CustomErrorHandlerMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RuleContext>();
    db.Database.Migrate();
}

app.MapGet("tax", HandleGetTax)
    .WithName("GetTaxes")
    .WithOpenApi();

app.MapPost("tax", HandlePostTax)
    .WithName("PostTaxes")
    .WithOpenApi();

async Task<decimal> HandleGetTax(TaxService svc, string municipality, DateTime date) => await svc.GetTax(municipality, date);
async Task HandlePostTax(TaxService svc, string municipality, decimal taxrate, DateTime startDateInclusive, DateTime endDateExclusive) => await svc.PostTax(municipality, taxrate, startDateInclusive, endDateExclusive);


app.Run();