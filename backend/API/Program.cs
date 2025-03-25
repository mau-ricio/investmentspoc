using Investments.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InvestmentsDbContext>(options =>
    options.UseSqlite("Data Source=investments.db"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/institutions", async (InvestmentsDbContext db) =>
    await db.Institutions.ToListAsync());

app.Run();