using MathProject.Host.Domain.Common;

namespace MathProject.Host.Domain.Aggregates.Subject;

/// <summary>
/// Предмет
/// </summary>
public class SubjectEntity : Entity
{
    public SubjectEntity() { }
    
    public SubjectEntity(string name)
    {
        _name = name;
    }
    
    /// <summary>
    /// Название предмета
    /// </summary>
    public string Name => _name;
    private string _name;
    
    /// <summary>
    /// Метод для добавления категории
    /// </summary>
    /// <param name="category"></param>
    public void AddTrainingCategory(TrainingCategoryEntity category)
    {
        TrainingCategories.Add(category);
    }

    #region virtual
    
    /// <summary>
    /// Коллекция категорий подготовок
    /// </summary>
    public virtual ICollection<TrainingCategoryEntity> TrainingCategories { get; private set; }

    #endregion
}