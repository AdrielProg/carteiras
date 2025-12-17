using Carteiras.Conta.Domain.Aggregates.ContaCategoria;
using Carteiras.Conta.Domain.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Carteiras.Conta.Domain.Data.Context;

/// <summary>
/// DbContext para o domínio Conta.
/// </summary>
public class ContaDbContext : DbContext
{
    public ContaDbContext(DbContextOptions<ContaDbContext> options) : base(options)
    {
    }

    public DbSet<ContaCategoria> ContaCategorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplicar configurações
        modelBuilder.ApplyConfiguration(new ContaCategoriaConfiguration());
    }
}

