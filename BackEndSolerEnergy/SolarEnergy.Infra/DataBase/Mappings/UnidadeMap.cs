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
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .Property(u => u.Local)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(u => u.Marca)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();
        
        builder
            .Property(u => u.Modelo)
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(u => u.IsActive)
            .IsRequired();
        
    }
}
