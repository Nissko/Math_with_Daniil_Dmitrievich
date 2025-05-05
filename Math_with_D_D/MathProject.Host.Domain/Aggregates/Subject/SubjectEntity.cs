using MathProject.Host.Domain.Aggregates.Subject.Categories;
using MathProject.Host.Domain.Common;

namespace MathProject.Host.Domain.Aggregates.Subject;

/// <summary>
/// Предмет
/// </summary>
public class SubjectEntity : Entity
{
    public SubjectEntity()
    {
        TrainingCategories = new HashSet<TrainingCategoryEntity>();
    }
    
    public SubjectEntity(string name) : this()
    {
        _name = name;
    }
    
    /// <summary>
    /// Название предмета
    /// </summary>
    public string Name => _name;
    private string _name;
    
    #region virtual
    
    /// <summary>
    /// Коллекция категорий подготовок
    /// </summary>
    public virtual ICollection<TrainingCategoryEntity> TrainingCategories { get; private set; }

    #endregion

    #region functions

    /// <summary>
    /// Метод для добавления категории
    /// </summary>
    public void AddTrainingCategory(TrainingCategoryEntity category)
    {
        TrainingCategories.Add(category);
    }

    /// <summary>
    /// Метод для изменения имени
    /// </summary>
    public void ChangeName(string newName)
    {
        if (newName == string.Empty || newName.Length == 0)
        {
            throw new NullReferenceException("Нельзя изменить на пустое название!");
        }
        
        _name = newName;
    }

    #endregion
}