namespace MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;

/// <summary>
/// Используется для окружения Subject, выводит его Training Categories
/// </summary>
public record AddTrainingCategoriesRequest
{
    public required Guid SubjectId { get; init; }
    public required IEnumerable<AddTrainingCategoryRequest> TrainingCategoryRequests { get; init; }
}