using CribBuzz.Infrastructure.Data;
using CribBuzz.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add Serilog configuration
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .Enrich.FromLogContext()
    .CreateLogger();

// Add Serilog to the logging system
builder.Host.UseSerilog();

// Use the extension method to register all services
builder.Services.AddInfrastructureServices(builder.Configuration);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register Automapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Register the Exception Handling Middleware (MUST be first in the pipeline)
app.UseMiddleware<ExceptionHandlingMiddleWare>();

// Enable Serilog request logging
app.UseSerilogRequestLogging(); // Logs HTTP requests

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
