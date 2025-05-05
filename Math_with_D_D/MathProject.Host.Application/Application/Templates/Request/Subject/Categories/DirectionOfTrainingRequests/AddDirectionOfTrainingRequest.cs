namespace MathProject.Host.Application.Application.Templates.Request.Subject.Categories.DirectionOfTrainingRequests;

/// <summary>
/// 
/// </summary>
public record AddDirectionOfTrainingRequest
{
    public required string Name { get; init; }
    public required int DisplayOrder { get; init; }
    public required DateTime Date { get; init; }
}