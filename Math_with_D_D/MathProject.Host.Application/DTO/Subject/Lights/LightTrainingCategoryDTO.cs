namespace MathProject.Host.Application.DTO.Subject.Lights;

public record LightTrainingCategoryDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int DisplayOrder { get; init; }
    public bool IsVisible { get; init; }
    public IEnumerable<LightDirectionOfTrainingDTO> DirectionOfTrainings { get; init; }
}