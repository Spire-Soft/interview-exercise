using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Ticketapi;
using Ticketapi.Data;
using Ticketapi.Modules;
using Ticketapi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Connect SQLite database
builder.Services.AddDbContext<TicketDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        builder => builder.WithOrigins("http://localhost:4200")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// Extract all the modules
var moduleType = typeof(IModule);
var modules = AppDomain.CurrentDomain.GetAssemblies()
    .SelectMany(s => s.GetTypes())
    .Where(p => moduleType.IsAssignableFrom(p) && !p.IsInterface)
    .Select(Activator.CreateInstance)
    .Cast<IModule>()
    .ToList();

// Register all the services
foreach (var module in modules)
{
    module.RegisterServices(builder.Services);
}

// Add services to the container
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Register Middleware
app.UseMiddleware<ExceptionMiddleware>();

foreach (var module in modules)
{
    module.MapEndpoints(app);
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/swagger");
            return;
        }

        await next();
    });

    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS
app.UseCors("AllowFrontend");

app.Run();