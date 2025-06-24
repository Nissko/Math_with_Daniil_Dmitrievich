using MathProject.Host.Application.DTO.Subject.CategoriesDtos;

namespace MathProject.Host.Application.Application.Interfaces.Subject.Categories
{
    public interface ILearningTopicsRepository
    {
        /// <summary>
        /// Получение всех тем обучений
        /// </summary>
        Task<IEnumerable<LearningTopicDTO>> GetLearningTopicsAsync();
        
        /// <summary>
        /// Получение всех подтем обучений по ид темы обучения
        /// </summary>
        Task<IEnumerable<SubthemeOfLearningsDTO>> GetSubthemeOfLearningsAsync(Guid learningTopicId);
    }
}