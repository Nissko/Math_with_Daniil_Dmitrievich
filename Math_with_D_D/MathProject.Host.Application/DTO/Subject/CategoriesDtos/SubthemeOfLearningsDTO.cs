namespace MathProject.Host.Application.DTO.Subject.CategoriesDtos
{
    public record SubthemeOfLearningsDTO
    {
        public Guid Id { get; init; }
        public Guid LearningTopicId { get; init; }
        public string Name { get; init; }
        public int DisplayOrder { get; init; }
        public bool IsVisible { get; init; }
    }
}