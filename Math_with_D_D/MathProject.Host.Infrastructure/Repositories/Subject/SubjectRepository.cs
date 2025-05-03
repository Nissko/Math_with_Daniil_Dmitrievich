using MathProject.Host.Application.Application.Interfaces.Subject;
using MathProject.Host.Application.Application.Templates.Request.Subject;
using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;
using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Application.DTO.Subject;
using MathProject.Host.Domain.Aggregates.Subject;
using Microsoft.EntityFrameworkCore;

namespace MathProject.Host.Infrastructure.Repositories.Subject;

public class SubjectRepository : ISubjectRepository
{
    private readonly IMathProjectContext _context;
    private readonly ICustomMapper _mapper;

    public SubjectRepository(IMathProjectContext context, ICustomMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<SubjectDTO>> GetSubjectsAsync()
    {
        var subject = await _context.Subject.ToListAsync();
        return _mapper.SubjectMapperProfile.GetSubjectDtos(subject);
    }

    public async Task<SubjectDTO> GetSubjectByIdAsync(Guid subjectId)
    {
        var subject = await _context.Subject.FirstOrDefaultAsync(s => s.Id == subjectId) ??
                      throw new ArgumentException("Предмет не найден");

        return _mapper.SubjectMapperProfile.GetSubjectDto(subject);
    }

    public async Task<SubjectDTO> CreateSubjectAsync(CreateSubjectRequest newSubjectRequest)
    {
        var subject = new SubjectEntity(newSubjectRequest.Name);

        if (newSubjectRequest.TrainingCategories.Any())
            foreach (var trainingCategory in newSubjectRequest.TrainingCategories)
                subject.AddTrainingCategory(new TrainingCategoryEntity(trainingCategory.Name, subject.Id,
                    trainingCategory.DisplayOrder));

        _context.Subject.Add(subject);
        await SaveChangesAsync(CancellationToken.None);

        return _mapper.SubjectMapperProfile.GetSubjectDto(subject);
    }

    public async Task<SubjectDTO> AddTrainingCategoriesAsync(AddTrainingCategoriesRequest trainingCategories)
    {
        var subject = await _context.Subject.FirstOrDefaultAsync(s => s.Id == trainingCategories.SubjectId) ??
                      throw new NullReferenceException("Не удалось найти предмет с таким идентификатором!");

        if (trainingCategories.TrainingCategoryRequests.Any())
        {
            foreach (var trainingCategory in trainingCategories.TrainingCategoryRequests)
            {
                var newTrainingCategories = new TrainingCategoryEntity(trainingCategory.Name, subject.Id,
                    trainingCategory.DisplayOrder);

                subject.AddTrainingCategory(newTrainingCategories);

                _context.TrainingCategory.Add(newTrainingCategories);
            }

            await SaveChangesAsync(CancellationToken.None);
        }

        return _mapper.SubjectMapperProfile.GetSubjectDto(subject);
    }

    public async Task<SubjectEntity> UpdateSubjectAsync(UpdateSubjectRequest updateSubjectRequest)
    {
        var subject = await _context.Subject.FirstOrDefaultAsync(s => s.Id == updateSubjectRequest.Id) ??
                      throw new NullReferenceException("Не удалось найти предмет с таким идентификатором");

        if (subject.Name == updateSubjectRequest.NewName) return subject;

        subject.ChangeName(updateSubjectRequest.NewName);

        _context.Subject.Update(subject);
        await SaveChangesAsync(CancellationToken.None);

        return subject;
    }

    public async Task DeleteSubjectAsync(Guid subjectId)
    {
        var subject = await _context.Subject.FirstOrDefaultAsync(s => s.Id == subjectId) ??
                      throw new NullReferenceException("Не удалось найти предмет с таким идентификатором");

        _context.Subject.Remove(subject);

        await SaveChangesAsync(CancellationToken.None);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}