using PacifiCorp.PSPortal.Domain;
using PacifiCorp.PSPortal.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
// Local developer config, ignored by Git
builder.Configuration.AddJsonFile("appsettings.Override.json", optional: true);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
//builder.Services.AddTransient<ILogger>();
builder.Services.AddDbContext<PSPortalDbContext>(options => options
    .UseSqlServer(configuration.GetConnectionString("PSPortalDb")));

builder.Services.AddMediatR(config => config
    .RegisterServicesFromAssembly(typeof(PacifiCorp.PSPortal.Data.Models.User).Assembly)
    .RegisterServicesFromAssembly(typeof(PacifiCorp.PSPortal.Domain.Models.User).Assembly));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Allows using TestHost for integration tests
public partial class Program { }
