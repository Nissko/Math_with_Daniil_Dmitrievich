namespace MathProject.Host.Application.DTO.Subject.CategoriesDtos;

public record LearningTopicDTO
{
    public Guid Id { get; init; }
    public Guid DirectionOfTrainingId { get; init; }
    public string Name { get; init; }
    public int DisplayOrder { get; init; }
    public bool IsVisible { get; init; }
};