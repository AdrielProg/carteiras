using Conta.Core.Aggregates.ContaCategoria;
using Conta.Data.Context;
using Shared.Core.Data.Repositories;
using Shared.Core.Interfaces;

namespace Conta.Data.Repositories;

/// <summary>
/// Implementação do repositório para ContaCategoria.
/// </summary>
public class ContaCategoriaRepository : Repository<ContaCategoria, Guid>, IRepository<ContaCategoria, Guid>
{
    public ContaCategoriaRepository(ContaDbContext context) : base(context)
    {
    }
}

