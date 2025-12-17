using System.Linq;
using System.Linq.Expressions;

namespace Shared.Core.Domain.Specification;

/// <summary>
/// Especificação que nega outra especificação.
/// </summary>
internal sealed class NotSpecification<T> : Specification<T>
{
    private readonly Specification<T> _specification;

    public NotSpecification(Specification<T> specification)
    {
        _specification = specification;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var expression = _specification.ToExpression();
        var notExpression = Expression.Not(expression.Body);

        return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
    }
}

