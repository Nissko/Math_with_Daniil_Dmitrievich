using MathProject.Host.Domain.Common;

namespace MathProject.Host.Domain.Aggregates.Subject.Categories;

/// <summary>
/// Категория подготовки
/// ОГЭ, ЕГЭ, ВПР и тд
/// </summary>
public class TrainingCategoryEntity : Entity
{
    public TrainingCategoryEntity()
    {
        DirectionOfTrainings = new List<DirectionOfTrainingEntity>();
    }

    public TrainingCategoryEntity(string name, Guid subjectId, int displayOrder) : this()
    {
        _name = name;
        _subjectId = subjectId;
        _displayOrder = displayOrder;
        _isVisible = true;
    }

    /// <summary>
    /// Название категории подготовки
    /// </summary>
    public string Name => _name;
    private string _name;
    
    /// <summary>
    /// Предмет для категории подготовки
    /// </summary>
    public virtual SubjectEntity Subject { get; private set; }
    private Guid _subjectId;
    
    #region Опции управления

    /// <summary>
    /// Показывать категорию подготовки
    /// </summary>
    public bool IsVisible => _isVisible;
    private bool _isVisible;
    
    /// <summary>
    /// Порядок отображения
    /// </summary>
    public string DisplayOrder => _displayOrder.ToString();
    private int _displayOrder;

    #endregion
    
    #region virtual

    /// <summary>
    /// Коллекция направлений обучения
    /// </summary>
    public virtual ICollection<DirectionOfTrainingEntity> DirectionOfTrainings { get; private set; }

    #endregion
    
    #region functions
    
    /// <summary>
    /// Метод для добавления направления обучения
    /// </summary>
    public void AddDirectionOfTraining(DirectionOfTrainingEntity directionOfTraining)
    {
        DirectionOfTrainings.Add(directionOfTraining);
    }
    
    /// <summary>
    /// Метод изменения имени
    /// </summary>
    public void ChangeName(string newName)
    {
        if (newName == string.Empty || newName.Length == 0)
        {
            throw new NullReferenceException("Нельзя изменить на пустое название!");
        }
        
        _name = newName;
    }

    /// <summary>
    /// Метод для изменения принадлежания к предмету
    /// </summary>
    public void ChangeSubject(Guid newSubjectId)
    {
        if (newSubjectId == Guid.Empty)
        {
            throw new NullReferenceException("Неправильный тип идентификатора!");
        }
        
        _subjectId = newSubjectId;
    }
    
    #endregion
}