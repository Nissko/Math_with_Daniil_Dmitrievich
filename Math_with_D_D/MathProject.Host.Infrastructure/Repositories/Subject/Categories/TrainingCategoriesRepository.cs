using MathProject.Host.Application.Application.Interfaces.Subject.Categories;
using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.DirectionOfTrainingRequests;
using MathProject.Host.Application.Application.Templates.Request.Subject.Categories.TrainingCategoryRequests;
using MathProject.Host.Application.Common.Interfaces;
using MathProject.Host.Application.DTO.Subject.CategoriesDtos;
using MathProject.Host.Domain.Aggregates.Subject.Categories;
using Microsoft.EntityFrameworkCore;

namespace MathProject.Host.Infrastructure.Repositories.Subject.Categories;

public class TrainingCategoriesRepository : ITrainingCategoryRepository
{
    private readonly IMathProjectContext _context;
    private readonly ICustomMapper _mapper;

    public TrainingCategoriesRepository(IMathProjectContext context, ICustomMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<IEnumerable<TrainingCategoryDto>> GetTrainingCategoriesAsync()
    {
        var trainingCategories = await _context.TrainingCategory.ToListAsync();

        return await _mapper.TrainingCategoryMapperProfile.GetTrainingCategoryDtos(trainingCategories);
    }
    
    public async Task<TrainingCategoryDto> AddTrainingCategoriesAsync(AddDirectionOfTrainingsRequest directionOfTrainings)
    {
        var trainingCategory =
            await _context.TrainingCategory.FirstOrDefaultAsync(s => s.Id == directionOfTrainings.TrainingCategoryId) ??
            throw new NullReferenceException("Не удалось найти категорию подготовки с таким идентификатором!");

        if (directionOfTrainings.DirectionOfTrainingRequests.Any())
        {
            foreach (var directionOfTraining in directionOfTrainings.DirectionOfTrainingRequests)
            {
                var newDirectionOfTrainingCategory = new DirectionOfTrainingEntity(directionOfTraining.Name,
                    directionOfTraining.Date, trainingCategory.Id, directionOfTraining.DisplayOrder);

                trainingCategory.AddDirectionOfTraining(newDirectionOfTrainingCategory);

                _context.DirectionOfTraining.Add(newDirectionOfTrainingCategory);
            }

            await SaveChangesAsync(CancellationToken.None);
        }

        return _mapper.TrainingCategoryMapperProfile.GetTrainingCategoryDto(trainingCategory);
    }

    public async Task<TrainingCategoryDto> UpdateTrainingCategoryAsync(
        UpdateTrainingCategoryRequest updateTrainingCategory)
    {
        var trainingCategory =
            await _context.TrainingCategory.FirstOrDefaultAsync(t => t.Id == updateTrainingCategory.Id) ??
            throw new NullReferenceException("Не удалось найти категорию подготовки с таким идентификатором!");

        if (updateTrainingCategory.NewName != null && updateTrainingCategory.NewName.Length > 0)
            trainingCategory.ChangeName(updateTrainingCategory.NewName);

        if (updateTrainingCategory.NewSubjectId != null && updateTrainingCategory.NewSubjectId != Guid.Empty)
        {
            var subject = _context.Subject.FirstOrDefault(s => s.Id == updateTrainingCategory.NewSubjectId);

            if (subject != null) trainingCategory.ChangeSubject(subject.Id);
        }

        _context.TrainingCategory.Update(trainingCategory);
        await SaveChangesAsync(CancellationToken.None);

        return _mapper.TrainingCategoryMapperProfile.GetTrainingCategoryDto(trainingCategory);
    }

    public async Task DeleteTrainingCategoryAsync(Guid trainingCategoryId)
    {
        var trainingCategory = await _context.TrainingCategory.FirstOrDefaultAsync(t => t.Id == trainingCategoryId) ??
                               throw new NullReferenceException("Не удалось найти категорию подготовки с таким идентификатором!");

        _context.TrainingCategory.Remove(trainingCategory);
        await SaveChangesAsync(CancellationToken.None);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}