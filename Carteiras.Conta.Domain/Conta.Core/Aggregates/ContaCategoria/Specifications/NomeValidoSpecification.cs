using System.Linq.Expressions;
using Shared.Core.Domain.Specification;

namespace Conta.Core.Aggregates.ContaCategoria.Specifications;

/// <summary>
/// Specification para validar se o nome da categoria é válido.
/// </summary>
public class NomeValidoSpecification : Specification<string>
{
    public override Expression<Func<string, bool>> ToExpression()
    {
        return nome => !string.IsNullOrWhiteSpace(nome) 
                    && nome.Length >= 3 
                    && nome.Length <= 100;
    }
}

