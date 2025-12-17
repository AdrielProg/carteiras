using Carteiras.Conta.Domain.Aggregates.ContaCategoria;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carteiras.Conta.Domain.Data.Configurations;

/// <summary>
/// Configuração do Entity Framework para o agregado ContaCategoria.
/// </summary>
public class ContaCategoriaConfiguration : IEntityTypeConfiguration<ContaCategoria>
{
    public void Configure(EntityTypeBuilder<ContaCategoria> builder)
    {
        // Nome da tabela
        builder.ToTable("ContaCategorias");

        // Chave primária
        builder.HasKey(c => c.Id);

        // Propriedades
        builder.Property(c => c.Id)
            .IsRequired();

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(100);

        // Índices
        builder.HasIndex(c => c.Nome)
            .IsUnique();

        // Ignorar DomainEvents (não persiste eventos)
        builder.Ignore(c => c.DomainEvents);
    }
}

