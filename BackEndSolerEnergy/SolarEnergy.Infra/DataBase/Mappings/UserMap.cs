using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarEnergy.Domain.Enuns;
using SolarEnergy.Domain.Models;

namespace SolarEnergy.Infra.DataBase.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure (EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Nome)
            .HasColumnName("NOME")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(u => u.Email)
            .HasColumnName("EMAIL")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(u => u.Password)
            .HasColumnName("PASSWORD")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(u => u.Image)
            .HasColumnName("IMAGE")
            .HasColumnType("VARBINARY")
            .HasMaxLength(8000);

        builder
            .Property(U => U.Role)
            .HasColumnName("ROLE")
            .HasDefaultValue(Permissoes.User);
    }
}
