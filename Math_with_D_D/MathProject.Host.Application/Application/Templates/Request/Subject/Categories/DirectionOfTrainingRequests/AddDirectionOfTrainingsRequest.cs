namespace MathProject.Host.Application.Application.Templates.Request.Subject.Categories.DirectionOfTrainingRequests;

public record AddDirectionOfTrainingsRequest
{
    public Guid TrainingCategoryId { get; init; }
    public IEnumerable<AddDirectionOfTrainingRequest> DirectionOfTrainingRequests { get; init; }
};