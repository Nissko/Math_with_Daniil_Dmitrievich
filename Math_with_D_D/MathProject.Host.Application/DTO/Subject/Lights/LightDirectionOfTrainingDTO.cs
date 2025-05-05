namespace MathProject.Host.Application.DTO.Subject.Lights;

public record LightDirectionOfTrainingDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Date { get; init; }
    public int DisplayOrder { get; init; }
    public bool IsVisible { get; init; }
};