namespace MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;

public record UpdateTrainingCategoryRequest
{
    /// <summary>
    /// Идентификатор существующей категории подготовки
    /// </summary>
    public required Guid Id { get; init; }
    
    /// <summary>
    /// Новый индентификатор предмета
    /// p.s. если был ошибочно добавлен не к тому предмету
    /// </summary>
    public Guid? NewSubjectId { get; init; }
    
    /// <summary>
    /// Новое название категории подготовки
    /// </summary>
    public string? NewName { get; init; } 
}