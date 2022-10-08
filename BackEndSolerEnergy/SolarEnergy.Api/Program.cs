using Microsoft.OpenApi.Models;
using SolarEnergy.Api.Config;
using System.Text;
using SolarEnergy.Domain.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SolarEnergy.Di.Ioc;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.RegisterServices();
builder.Services.RegisterRepositories();

builder.Services.AddControllers();

var key = Encoding.ASCII.GetBytes(Settings.Secret);

builder.Services.RegisterAuthentication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options => 
{
    options.SwaggerDoc("v1", 
        new OpenApiInfo
        {
            Title = "SolarEnergy.Api",
            Version = "v1",
            Description = "Api desenvolvida para a Aplicação Solar Energy!",
            Contact = new OpenApiContact
            {
                Name = "Edmilson Gomes",
                Url = new Uri("https://github.com/edmilsondmx"),
                Email = "edmilsondmx@gmail.com",
            }
        }
    );
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
        {
            Description =   @"JWT Authorization header using the Bearer scheme. 
                            Escreva 'Bearer' [espaço] e o token gerado no login na caixa abaixo.
                            Exemplo: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
                {
                Reference = new OpenApiReference
                    {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                    },
                },
            new List<string>()
        }
    });
});

builder.Services.AddCors(options => 
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy => 
        {
            policy.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<ErrorMiddleware>();

app.Run();
