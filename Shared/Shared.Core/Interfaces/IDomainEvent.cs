namespace Shared.Core.Interfaces;

/// <summary>
/// Interface base para eventos de domínio.
/// Eventos de domínio representam algo que aconteceu no domínio e que outras partes do sistema podem estar interessadas.
/// </summary>
public interface IDomainEvent
{
    /// <summary>
    /// Data e hora em que o evento ocorreu.
    /// </summary>
    DateTime OcorreuEm { get; }
    
    /// <summary>
    /// Identificador único do evento.
    /// </summary>
    Guid EventId { get; }
}

