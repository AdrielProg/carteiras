using Conta.Domain.Aggregates.ContaCategoria;
using Conta.Domain.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Conta.Domain.Data.Context;

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

