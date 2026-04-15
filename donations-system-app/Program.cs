using Microsoft.EntityFrameworkCore;
using donations_system_app.Data;
using donations_system_app.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DonationsDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register services
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IDonationService, DonationService>();
builder.Services.AddScoped<IRequestService, RequestService>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
