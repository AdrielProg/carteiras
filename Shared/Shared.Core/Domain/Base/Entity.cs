using Shared.Core.Interfaces;

namespace Shared.Core.Domain.Base;

/// <summary>
/// Classe base abstrata para todas as entidades do domínio.
/// Fornece implementação padrão para comparação, hash code e gerenciamento de eventos de domínio.
/// </summary>
/// <typeparam name="TKey">Tipo da chave primária da entidade.</typeparam>
public abstract class Entity<TKey> : IEntity<TKey>
{
    protected Entity()
    {
        if (typeof(TKey) == typeof(Guid))
        {
            Id = (TKey)(object)Guid.NewGuid();
        }
    }

    public TKey Id { get; protected set; } = default!;

    private List<IDomainEvent>? _domainEvents;
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly() ?? new List<IDomainEvent>().AsReadOnly();

    public void AdicionarDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents ??= new List<IDomainEvent>();
        _domainEvents.Add(domainEvent);
    }

    public void RemoverDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents?.Remove(domainEvent);
    }

    public void LimparDomainEvents()
    {
        _domainEvents?.Clear();
    }

    #region BaseBehaviours

    public override bool Equals(object? obj)
    {
        var compareTo = obj as Entity<TKey>;

        if (ReferenceEquals(this, compareTo)) return true;
        if (ReferenceEquals(null, compareTo)) return false;

        return Id!.Equals(compareTo.Id);
    }

    public static bool operator ==(Entity<TKey>? a, Entity<TKey>? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity<TKey>? a, Entity<TKey>? b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType().GetHashCode() ^ 93) + Id!.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }

    #endregion
}

