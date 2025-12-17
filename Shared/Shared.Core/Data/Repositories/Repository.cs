using Microsoft.EntityFrameworkCore;
using Shared.Core.Interfaces;
using System.Linq.Expressions;

namespace Shared.Core.Data.Repositories;

/// <summary>
/// Implementação genérica do repositório usando Entity Framework.
/// </summary>
/// <typeparam name="T">Tipo do agregado (deve implementar IAggregateRoot).</typeparam>
/// <typeparam name="TKey">Tipo da chave primária do agregado.</typeparam>
public abstract class Repository<T, TKey> : IRepository<T, TKey> where T : class, IAggregateRoot
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<T> AdicionarAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual Task<T> AtualizarAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        return Task.FromResult(entity);
    }

    public virtual async Task RemoverAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var entity = await BuscarPorIdAsync(id, cancellationToken);
        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

    public virtual Task RemoverAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public virtual async Task<IEnumerable<T>> BuscarAsync(ISpecification<T>? specification = null, CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsQueryable();

        if (specification is not null)
            query = query.Where(specification.ToExpression());

        return await query.ToListAsync(cancellationToken);
    }

    public virtual async Task<T?> BuscarPorIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(new object[] { id! }, cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> ListarAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public virtual async Task<bool> ExisteAsync(TKey id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(new object[] { id! }, cancellationToken) != null;
    }

    public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}

