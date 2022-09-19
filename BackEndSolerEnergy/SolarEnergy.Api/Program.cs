using SolarEnergy.Api.Data;
using Microsoft.OpenApi.Models;
using SolarEnergy.Infra.DataBase.Repositories;
using SolarEnergy.Domain.Interfaces.Repositories;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
                Email = "edmilsondmx@gmail.com"
            }
        });
});
builder.Services.AddDbContext<SolarDbContext>();

builder.Services.AddScoped<IUnidadeRepository, UnidadeRepository>();
builder.Services.AddScoped<IGeracaoRepository, GeracaoRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
