namespace MathProject.Host.Application.Application.Templates.Request.Subject;

public record UpdateSubjectRequest
{
    /// <summary>
    /// Идентификатор существующего предмета
    /// </summary>
    public required Guid Id { get; init; }
    
    /// <summary>
    /// Новое название предмета
    /// </summary>
    public required string NewName { get; init; } 
}