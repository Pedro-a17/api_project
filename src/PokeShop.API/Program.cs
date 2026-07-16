using Microsoft.OpenApi.Models;
using PokeShop.Infra;
using PokeShop.Application;
using PokeShop.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddScoped<AdminOnlyFilter>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PokeShop API", Version = "v1" });

    c.AddSecurityDefinition("AdminPassword", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "X-Super-Password",
        Type = SecuritySchemeType.ApiKey,
        Description = "Type the expected admin password to proceede"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "AdminPassword"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "prodCors", configurePolicy: policy =>
    {
        policy.WithOrigins("https://pokeshop.com")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });

    options.AddPolicy(name: "devCors", configurePolicy: policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    try
    {
        await app.Services.SeedDatabaseAsync();
    }  
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[Seed error]: It was not possible to populate the database. Details: {ex.Message}");
        Console.ResetColor();
    }

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("devCors");
}
else
{
    app.UseCors("prodCors");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
