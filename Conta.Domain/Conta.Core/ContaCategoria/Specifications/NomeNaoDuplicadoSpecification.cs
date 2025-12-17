using System.Linq.Expressions;
using Shared.Core.Domain.Specification;
using Conta.Domain.Aggregates.ContaCategoria;

namespace Conta.Domain.Aggregates.ContaCategoria.Specifications;

/// <summary>
/// Specification para verificar se o nome não está duplicado.
/// </summary>
public class NomeNaoDuplicadoSpecification : Specification<ContaCategoria>
{
    private readonly string _nome;
    private readonly Guid? _excluirId;

    public NomeNaoDuplicadoSpecification(string nome, Guid? excluirId = null)
    {
        _nome = nome;
        _excluirId = excluirId;
    }

    public override Expression<Func<ContaCategoria, bool>> ToExpression()
    {
        return categoria => categoria.Nome.Equals(_nome, StringComparison.OrdinalIgnoreCase)
                        && (_excluirId == null || categoria.Id != _excluirId.Value);
    }
}

