namespace MathProject.Host.Application.DTO.Subject.Categories;

public record LightTrainingCategoryDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int DisplayOrder { get; init; }
    public bool IsVisible { get; init; }
}