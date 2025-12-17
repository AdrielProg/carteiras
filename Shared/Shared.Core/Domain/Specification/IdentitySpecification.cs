using System.Linq.Expressions;

namespace Shared.Core.Domain.Specification;

/// <summary>
/// Especificação de identidade que sempre retorna true.
/// Usada como valor padrão para especificações vazias.
/// </summary>
internal sealed class IdentitySpecification<T> : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        return x => true;
    }
}

