using MathProject.Host.Application.DTO.Subject.Lights;

namespace MathProject.Host.Application.DTO.Subject;

public record SubjectDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public IEnumerable<LightTrainingCategoryDto> TrainingCategories { get; init; }
}