using MathProject.Host.Application.Application.Interfaces.Subject.Categories;
using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Application.DTO.Subject.CategoriesDtos;
using Microsoft.EntityFrameworkCore;

namespace MathProject.Host.Infrastructure.Repositories.Subject.Categories;

public class DirectionOfTrainingRepository : IDirectionOfTrainingRepository
{
    private readonly IMathProjectContext _context;
    private readonly ICustomMapper _mapper;

    public DirectionOfTrainingRepository(IMathProjectContext context, ICustomMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<DirectionOfTrainingDTO>> GetDirectionOfTrainingsAsync()
    {
        var directionOfTrainings = await _context.DirectionOfTraining.ToListAsync();
        return await _mapper.DirectionOfTrainingMapperProfile.GetDirectionOfTrainingDtos(directionOfTrainings);
    }

    public async Task<DirectionOfTrainingDTO> GetDirectionOfTrainingsByIdAsync(Guid directionOfTrainingId)
    {
        var directionOfTraining =
            await _context.DirectionOfTraining.FirstOrDefaultAsync(d => d.Id == directionOfTrainingId);
        if (directionOfTraining == null)
            throw new ArgumentNullException(
                $"Направление обучения с идентификатором {directionOfTrainingId} не найдено в системе");

        return _mapper.DirectionOfTrainingMapperProfile.GetDirectionOfTrainingDto(directionOfTraining);
    }

    public async Task<IEnumerable<LearningTopicDTO>> GetLearningTopicsAsync(Guid directionOfTrainingId)
    {
        var learningTopics = await _context.LearningTopics
            .Where(lt => lt.DirectionOfTraining.Id == directionOfTrainingId).ToListAsync();

        if (!learningTopics.Any())
            return new List<LearningTopicDTO>();

        return await _mapper.LearningTopicMapperProfile.GetLearningTopicsDto(learningTopics);
    }

    //TODO:тест CI/CD
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    { 
        await _context.SaveChangesAsync(cancellationToken);
    }
}