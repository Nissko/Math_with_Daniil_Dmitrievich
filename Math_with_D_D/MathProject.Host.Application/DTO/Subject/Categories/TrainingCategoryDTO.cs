namespace MathProject.Host.Application.DTO.Subject.Categories;

public record TrainingCategoryDTO
{
    public Guid Id { get; init; }
    public Guid SubjectId { get; init; }
    public string SubjectName { get; init; }
    public string Name { get; init; }
    public int DisplayOrder { get; init; }
    public bool IsVisible { get; init; }
}