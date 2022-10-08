using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SolarEnergy.Domain.Models;
using SolarEnergy.Infra.DataBase.Mappings;

namespace SolarEnergy.Infra.DataBase;

public class SolarDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public SolarDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Unidade> Unidades { get; set; }
    public DbSet<Geracao> Geracoes { get; set; }
    public DbSet<User> Users { get; set; }

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

        modelBuilder.ApplyConfiguration(new UserMap());
    }
}
