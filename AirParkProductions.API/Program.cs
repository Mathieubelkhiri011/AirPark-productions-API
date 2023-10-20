using Microsoft.OpenApi.Models;
using AirParkProductions.API.Exceptions;
using AirParkProductions.Application;
using AirParkProductions.Infrastructure;
using Newtonsoft.Json;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options => options.LowercaseUrls = true);

#if DEBUG
string connectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
#else
            string connectionStr = Environment.GetEnvironmentVariable("MYSQLCONNSTR_MySQLDB");
#endif

builder.Services.AddDatabaseContext(connectionStr);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(opt =>
    {
        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
        opt.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
        opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    })
    .AddControllersAsServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AirParkProductions - API", Version = "v" + typeof(Program).Assembly.GetCustomAttribute<AssemblyFileVersionAttribute>().Version });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,

            },
            new List<string>()
        }
    });
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddMappers();
builder.Services.AddRepositories();
builder.Services.AddServices();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.ConfigureCustomExceptionMiddleware();

// L'ORDRE DES DEUX EST IMPORTANT
// app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
