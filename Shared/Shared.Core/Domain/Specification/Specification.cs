using System.Linq.Expressions;

namespace Shared.Core.Domain.Specification;

/// <summary>
/// Classe abstrata base para implementação do padrão Specification.
/// Permite composição de regras de negócio usando operadores lógicos (AND, OR, NOT).
/// </summary>
/// <typeparam name="T">Tipo da entidade que será avaliada pela especificação.</typeparam>
public abstract class Specification<T>
{
    private static readonly Specification<T> All = new IdentitySpecification<T>();

    /// <summary>
    /// Verifica se a entidade atende à especificação.
    /// </summary>
    public bool IsSatisfiedBy(T entity)
    {
        var predicate = ToExpression().Compile();
        return predicate(entity);
    }

    /// <summary>
    /// Converte a especificação em uma expressão lambda.
    /// </summary>
    public abstract Expression<Func<T, bool>> ToExpression();

    /// <summary>
    /// Combina duas especificações com operador AND.
    /// </summary>
    public Specification<T> And(Specification<T> specification)
    {
        if (this == All)
            return specification;
        if (specification == All)
            return this;

        return new AndSpecification<T>(this, specification);
    }

    /// <summary>
    /// Combina duas especificações com operador OR.
    /// </summary>
    public Specification<T> Or(Specification<T> specification)
    {
        if (this == All || specification == All)
            return All;

        return new OrSpecification<T>(this, specification);
    }

    /// <summary>
    /// Nega a especificação atual.
    /// </summary>
    public Specification<T> Not()
    {
        return new NotSpecification<T>(this);
    }
}

