using Shared.Core.Domain.Base;
using Shared.Core.Interfaces;
using Shared.Core.Domain.Specification;
using Conta.Core.Aggregates.ContaCategoria.Specifications;

namespace Conta.Core.Aggregates.ContaCategoria;

/// <summary>
/// Agregado raiz ContaCategoria.
/// Representa uma categoria de conta.
/// </summary>
public class ContaCategoria : AggregateRoot<Guid>
{
    public string Nome { get; private set; } = string.Empty;

    // Construtor privado para garantir invariantes
    private ContaCategoria() { }

    public ContaCategoria(string nome)
    {
        Id = Guid.NewGuid();
        
        // Validação usando Specification
        var nomeValidoSpec = new NomeValidoSpecification();
        if (!nomeValidoSpec.IsSatisfiedBy(nome))
        {
            throw new Shared.Core.Domain.Exceptions.DomainException(
                "O nome da categoria deve ter entre 3 e 100 caracteres e não pode estar vazio.");
        }

        Nome = nome;
    }

    /// <summary>
    /// Atualiza o nome da categoria.
    /// </summary>
    public void AtualizarNome(string novoNome)
    {
        // Validação usando Specification
        var nomeValidoSpec = new NomeValidoSpecification();
        if (!nomeValidoSpec.IsSatisfiedBy(novoNome))
        {
            throw new Shared.Core.Domain.Exceptions.DomainException(
                "O nome da categoria deve ter entre 3 e 100 caracteres e não pode estar vazio.");
        }

        Nome = novoNome;
    }
}

