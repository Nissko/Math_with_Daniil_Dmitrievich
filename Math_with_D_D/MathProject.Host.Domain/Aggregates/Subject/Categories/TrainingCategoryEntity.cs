using MathProject.Host.Domain.Common;

namespace MathProject.Host.Domain.Aggregates.Subject;

/// <summary>
/// Категория подготовки
/// ОГЭ, ЕГЭ, ВПР и тд
/// </summary>
public class TrainingCategoryEntity : Entity
{
    public TrainingCategoryEntity() { }
    
    public TrainingCategoryEntity(string name, Guid subjectId)
    {
        _name = name;
        _subjectId = subjectId;
    }
    
    /// <summary>
    /// Название категории подготовки
    /// </summary>
    public string Name => _name;
    private string _name;
    
    /// <summary>
    /// Предмет для категории подготовки
    /// </summary>
    public SubjectEntity Subject { get; private set; }
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
    public string DisplayOrder => _displayOrder;
    private string _displayOrder;

    #endregion
    
    #region virtual

    /// <summary>
    /// Коллекция направлений обучения
    /// </summary>
    public virtual ICollection<DirectionOfTrainingEntity> DirectionOfTrainings { get; private set; }

    #endregion
}