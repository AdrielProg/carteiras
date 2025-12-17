using Shared.Core.Interfaces;

namespace Shared.Core.Domain.Base;

/// <summary>
/// Classe base abstrata para agregados raiz.
/// Herda de Entity e implementa IAggregateRoot.
/// </summary>
/// <typeparam name="TKey">Tipo da chave primária do agregado.</typeparam>
public abstract class AggregateRoot<TKey> : Entity<TKey>, IAggregateRoot
{
    // Herda todos os comportamentos de Entity (Equals, GetHashCode, DomainEvents, etc.)
}

