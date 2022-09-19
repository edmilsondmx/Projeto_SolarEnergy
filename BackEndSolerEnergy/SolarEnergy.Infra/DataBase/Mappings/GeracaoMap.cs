using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolarEnergy.Api.Models;

namespace SolarEnergy.Infra.DataBase.Mappings;

public class GeracaoMap : IEntityTypeConfiguration<Geracao>
{
    public void Configure(EntityTypeBuilder<Geracao> builder)
    {
        builder.ToTable("Geracoes");

        builder.HasKey(g => g.Id);

        builder
            .Property(g => g.Data)
            .IsRequired();

        builder
            .Property(g => g.Kw)
            .HasColumnType("int")
            .IsRequired();

        builder
            .HasOne(g => g.Unidade)
            .WithMany(u => u.Geracoes)
            .HasForeignKey(g => g.UnidadeId);
    }
}
