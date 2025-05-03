using MathProject.Host.Application.DTO.Subject.Categories;

namespace MathProject.Host.Application.DTO.Subject;

public record SubjectDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public IEnumerable<LightTrainingCategoryDTO> TrainingCategories { get; init; }
}