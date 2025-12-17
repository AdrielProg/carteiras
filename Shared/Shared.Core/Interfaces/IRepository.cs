using System.Linq.Expressions;

namespace Shared.Core.Interfaces;

/// <summary>
/// Interface genérica para repositórios.
/// Define operações básicas de acesso a dados para agregados.
/// </summary>
/// <typeparam name="T">Tipo do agregado (deve implementar IAggregateRoot).</typeparam>
/// <typeparam name="TKey">Tipo da chave primária do agregado.</typeparam>
public interface IRepository<T, TKey> where T : IAggregateRoot
{
    /// <summary>
    /// Busca um agregado por seu identificador.
    /// </summary>
    Task<T?> BuscarPorIdAsync(TKey id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Adiciona um novo agregado.
    /// </summary>
    Task<T> AdicionarAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Atualiza um agregado existente.
    /// </summary>
    Task<T> AtualizarAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Remove um agregado por seu identificador.
    /// </summary>
    Task RemoverAsync(TKey id, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Remove um agregado.
    /// </summary>
    Task RemoverAsync(T entity, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Busca agregados usando uma specification.
    /// Se specification for null, retorna todos os registros.
    /// </summary>
    Task<IEnumerable<T>> BuscarAsync(ISpecification<T>? specification = null, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Lista todos os agregados.
    /// </summary>
    Task<IEnumerable<T>> ListarAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Verifica se existe um agregado com o identificador especificado.
    /// </summary>
    Task<bool> ExisteAsync(TKey id, CancellationToken cancellationToken = default);
}
