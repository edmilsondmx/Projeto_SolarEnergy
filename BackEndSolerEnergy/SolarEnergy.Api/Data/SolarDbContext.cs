using Microsoft.EntityFrameworkCore;
using SolarEnergy.Api.Models;

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

        modelBuilder.Entity<Unidade>(entidade =>
        {
            entidade.ToTable("Unidades");

            entidade.HasKey(u => u.Id);

            entidade
                .Property(u => u.Apelido)
                .HasMaxLength(50)
                .IsRequired();
            
            entidade
                .Property(u => u.Local)
                .HasMaxLength(100)
                .IsRequired();
            
            entidade
                .Property(u => u.Marca)
                .HasMaxLength(50)
                .IsRequired();
            
            entidade
                .Property(u => u.Modelo)
                .HasMaxLength(100)
                .IsRequired();
            
            entidade
                .Property(u => u.IsActive)
                .IsRequired();
            
        });

        modelBuilder.Entity<Geracao>(entidade =>
        {
            entidade.ToTable("Gerações");

            entidade.HasKey(g => g.Id);

            entidade
                .Property(g => g.Data)
                .IsRequired();

            entidade
                .Property(g => g.Kw)
                .IsRequired();

            entidade
                .HasOne(g => g.Unidade)
                .WithMany(u => u.Geracoes)
                .HasForeignKey(g => g.UnidadeId);

        });
    }
}
