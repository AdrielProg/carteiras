using System.Linq.Expressions;

namespace Shared.Core.Domain.Specification;

/// <summary>
/// Especificação que combina duas especificações com operador OR.
/// </summary>
internal sealed class OrSpecification<T> : Specification<T>
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;

    public OrSpecification(Specification<T> left, Specification<T> right)
    {
        _right = right;
        _left = left;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = _left.ToExpression();
        var rightExpression = _right.ToExpression();

        var invokedExpression = Expression.Invoke(rightExpression, leftExpression.Parameters);

        return (Expression<Func<T, bool>>)Expression.Lambda(
            Expression.OrElse(leftExpression.Body, invokedExpression), 
            leftExpression.Parameters);
    }
}

