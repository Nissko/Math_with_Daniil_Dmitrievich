namespace MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;

/// <summary>
/// Используется в окружении Training Category
/// </summary>
public record AddTrainingCategoryRequest
{
    public required string Name { get; init; }
    public required int DisplayOrder { get; init; }
}