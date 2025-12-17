namespace Shared.Core.Interfaces;

/// <summary>
/// Interface base para todas as entidades do domínio.
/// </summary>
/// <typeparam name="TKey">Tipo da chave primária da entidade.</typeparam>
public interface IEntity<TKey>
{
    /// <summary>
    /// Identificador único da entidade.
    /// </summary>
    TKey Id { get; }
}

