using MathProject.Host.Application.Application.Interfaces.Subject.Categories;
using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Application.DTO.Subject.CategoriesDtos;
using Microsoft.EntityFrameworkCore;

namespace MathProject.Host.Infrastructure.Repositories.Subject.Categories;

public class LearningTopicsRepository : ILearningTopicsRepository
{
    private readonly IMathProjectContext _context;
    private readonly ICustomMapper _mapper;

    public LearningTopicsRepository(IMathProjectContext context, ICustomMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<LearningTopicDTO>> GetLearningTopicsAsync()
    {
        var learningTopics = await _context.LearningTopics.ToListAsync();
        if (!learningTopics.Any())
            return new List<LearningTopicDTO>();
        
        return await _mapper.LearningTopicMapperProfile.GetLearningTopicsDto(learningTopics);
    }

    public async Task<IEnumerable<SubthemeOfLearningsDTO>> GetSubthemeOfLearningsAsync(Guid learningTopicId)
    {
        var subthemeOfLearnings =
            await _context.SubthemesOfLearning.Where(st => st.LearningTopicsEntity.Id == learningTopicId).ToListAsync();
        if (!subthemeOfLearnings.Any())
            return new List<SubthemeOfLearningsDTO>();

        return await _mapper.SubthemeOfLearningMapperProfile.GetSubthemeOfLearningsDto(subthemeOfLearnings);
    }
}