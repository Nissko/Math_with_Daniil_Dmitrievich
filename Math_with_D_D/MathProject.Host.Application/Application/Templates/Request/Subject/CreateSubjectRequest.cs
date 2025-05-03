using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;

namespace MathProject.Host.Application.Application.Templates.Request.Subject;

public record CreateSubjectRequest
{
    /// <summary>
    /// Название предмета
    /// </summary>
    public required string Name { get; init; } 
    
    public required IEnumerable<AddTrainingCategoryRequest> TrainingCategories { get; init; }
}