using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarEnergy.Domain.Models;

namespace SolarEnergy.Infra.DataBase.Mappings;

public class UnidadeMap : IEntityTypeConfiguration<Unidade>
{
    public void Configure(EntityTypeBuilder<Unidade> builder)
    {
        builder.ToTable("Unidades");

        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Apelido)
            .HasColumnName("APELIDO")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .Property(u => u.Local)
            .HasColumnName("LOCAL")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(u => u.Marca)
            .HasColumnName("MARCA")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .Property(u => u.Modelo)
            .HasColumnName("MODELO")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(u => u.IsActive)
            .HasColumnName("ACTIVE")
            .IsRequired();
        
    }
}
