using CatalogService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ADD THIS: Configure Entity Framework to use SQLite
// UPDATE THIS BLOCK:
builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// ... the rest stays the same (Swagger, HttpsRedirection, MapControllers, Run)

// Configure the HTTP request pipeline.
// 2. Enable Swagger middleware (best practice is to only show it in Development mode)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); 

app.Run();