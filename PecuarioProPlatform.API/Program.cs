using Microsoft.EntityFrameworkCore;
using PecuarioProPlatform.API.BusinessAdministration.Application.Internal.CommandServices;
using PecuarioProPlatform.API.BusinessAdministration.Application.Internal.QueryServices;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;
using PecuarioProPlatform.API.BusinessAdministration.Infrastructure.Persistence.EFC.Repositories;
using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using PecuarioProPlatform.API.Shared.Interfaces.ASP.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
} );




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add Database Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//Configure Database Context and Logging Level
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null)
    {
        if (builder.Environment.IsDevelopment())
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging().EnableDetailedErrors();
        }
        else if (builder.Environment.IsProduction())
        {
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableDetailedErrors();
        }
    }
});


//Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);


//Configure Dependency Injections

//Shared Bounded Context Injection Configuration

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


//BusinessAdministration Bounded Context Dependency Injections
builder.Services.AddScoped<IBovineRepository, BovineRepository>();
builder.Services.AddScoped<IBovineCommandService, BovineCommandService>();
builder.Services.AddScoped<IBovineQueryService, BovineQueryService>();

builder.Services.AddScoped<ICampaignRepository, CampaignRepository>();
builder.Services.AddScoped<ICampaignCommandService, CampaignCommandService>();
builder.Services.AddScoped<ICampaignQueryService, CampaignQueryService>();



var app = builder.Build();




//Verify DataBase Objects are created
using (var scope = app.Services.CreateScope() )
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

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