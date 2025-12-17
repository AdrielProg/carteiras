using System.Linq.Expressions;
using Shared.Core.Domain.Specification;

namespace Shared.Core.Interfaces;

/// <summary>
/// Interface para o padrão Specification, permitindo composição de regras de negócio.
/// </summary>
/// <typeparam name="T">Tipo da entidade que será avaliada pela especificação.</typeparam>
public interface ISpecification<T>
{
    /// <summary>
    /// Verifica se a entidade atende à especificação.
    /// </summary>
    /// <param name="entity">Entidade a ser avaliada.</param>
    /// <returns>True se a entidade atende à especificação, caso contrário False.</returns>
    bool IsSatisfiedBy(T entity);

    /// <summary>
    /// Converte a especificação em uma expressão lambda.
    /// </summary>
    Expression<Func<T, bool>> ToExpression();
}

