using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PecuarioProPlatform.API.BusinessAdministration.Application.Internal.CommandServices;
using PecuarioProPlatform.API.BusinessAdministration.Application.Internal.QueryServices;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Repositories;
using PecuarioProPlatform.API.BusinessAdministration.Domain.Services;
using PecuarioProPlatform.API.BusinessAdministration.Infrastructure.Persistence.EFC.Repositories;
using PecuarioProPlatform.API.IAM.Application.Internal.CommandServices;
using PecuarioProPlatform.API.IAM.Application.Internal.OutboundServices;
using PecuarioProPlatform.API.IAM.Application.Internal.QueryServices;
using PecuarioProPlatform.API.IAM.Domain.Repositories;
using PecuarioProPlatform.API.IAM.Domain.Services;
using PecuarioProPlatform.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using PecuarioProPlatform.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using PecuarioProPlatform.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using PecuarioProPlatform.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using PecuarioProPlatform.API.IAM.Infrastructure.Tokens.JWT.Services;
using PecuarioProPlatform.API.IAM.Interfaces.ACL;
using PecuarioProPlatform.API.IAM.Interfaces.ACL.Services;
using PecuarioProPlatform.API.Shared.Application.Internal.CommandServices;
using PecuarioProPlatform.API.Shared.Application.Internal.QueryServices;
using PecuarioProPlatform.API.Shared.Domain.Repositories;
using PecuarioProPlatform.API.Shared.Domain.Services;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Configuration;
using PecuarioProPlatform.API.Shared.Infraestructure.Persistence.EFC.Repositories;
using PecuarioProPlatform.API.Shared.Interfaces.ASP.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
} );
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



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "ACME.PecuarioProPlatform.API",
                Version = "v1",
                Description = "Pecuario Pro Platform API",
                // TermsOfService = new Uri("https://acme-learning.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "Pecuario Pro",
                    Email = "contact@pecuario.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            } 
        });
    });






//Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//Add CORS Policy

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowedAllPolicy",
            policy => policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    });

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

builder.Services.AddScoped<IBreedRepository, BreedRepository>();
builder.Services.AddScoped<IBreedCommandService, BreedCommandService>();
builder.Services.AddScoped<IBreedQueryService, BreedQueryService>();



builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<IDistrictCommandService, DistrictCommandService>();
builder.Services.AddScoped<IDistrictQueryService, DistrictQueryService>();


builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityCommandService, CityCommandService>();
builder.Services.AddScoped<ICityQueryService, CityQueryService>();


builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentCommandService, DepartmentCommandService>();
builder.Services.AddScoped<IDepartmentQueryService, DepartmentQueryService>();

// IAM Bounded Context Injection Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();
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

// Apply CORS Policy

app.UseCors("AllowedAllPolicy");

//Add Authorization Middleware 

app.UseRequestAuthorization();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();