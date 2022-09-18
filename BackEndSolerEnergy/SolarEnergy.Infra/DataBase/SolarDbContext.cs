using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SolarEnergy.Api.Models;
using SolarEnergy.Infra.DataBase.Mappings;

namespace SolarEnergy.Api.Data;

public class SolarDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public SolarDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Unidade> Unidades { get; set; }
    public DbSet<Geracao> Geracoes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(
            _configuration.GetConnectionString("ConexaoBanco")
        );
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UnidadeMap());

        modelBuilder.ApplyConfiguration(new GeracaoMap());
    }
}
