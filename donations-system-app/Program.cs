using Microsoft.EntityFrameworkCore;
using donations_system_app.Data;
using donations_system_app.Services;
using donations_system_app.Services.Requests;

var builder = WebApplication.CreateBuilder(args);

// Agregamos los servicios al contenedor
builder.Services.AddControllers();
builder.Services.AddDbContext<DonationsDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IDonationService, DonationService>();
builder.Services.AddTransient<IRequestService, RequestService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
