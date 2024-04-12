using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeniumCurriculo.Models;

namespace SeniumCurriculo.Data;

public class UsuarioMap : IEntityTypeConfiguration<UsuarioModel>
{
    public void Configure(EntityTypeBuilder<UsuarioModel> builder)
    {
        builder.HasKey(x => x.id);
       
        builder.Property(x => x.id)
            .UseIdentityColumn()
            .HasColumnType("BIGINT");
        
        builder.Property(x => x.name)
            .IsRequired()
            .HasMaxLength(80)
            .HasColumnName("Nome")
            .HasColumnType("VARCHAR(80)");

        builder.Property(x => x.Cidade)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("Cidade")
            .HasColumnType("VARCHAR(80)");

        builder.Property(x => x.NumeroTelefone)
            .IsRequired()
            .HasMaxLength(15)
            .HasColumnName("NumeroTelefone")
            .HasColumnType("VARCHAR(15)");
    }
}