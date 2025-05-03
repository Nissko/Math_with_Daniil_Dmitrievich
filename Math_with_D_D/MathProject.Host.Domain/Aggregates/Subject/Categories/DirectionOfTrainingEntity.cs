using MathProject.Host.Domain.Common;

namespace MathProject.Host.Domain.Aggregates.Subject;

/// <summary>
/// Направление обучения
/// ОГЭ ФИПИ, ОГЭ 2024(2023), ОГЭ 2023
/// </summary>
public class DirectionOfTrainingEntity : Entity
{
    public DirectionOfTrainingEntity()
    {
        LearningTopics = new HashSet<LearningTopicsEntity>();
    }

    public DirectionOfTrainingEntity(string name, DateTime dateTrainingDir, Guid trainingCategoryId,
        int displayOrder) : this()
    {
        _name = name;
        _dateTrainingDir = dateTrainingDir;
        _trainingCategoryId = trainingCategoryId;
        _displayOrder = displayOrder;
    }

    /// <summary>
    /// Название
    /// </summary>
    public string Name => _name;
    private string _name;

    /// <summary>
    /// Год подготовки
    /// </summary>
    public string DateTrainingDir => _dateTrainingDir.ToString("YYYY");
    private DateTime _dateTrainingDir;
    
    /// <summary>
    /// Категория подготовки
    /// </summary>
    public virtual TrainingCategoryEntity TrainingCategory { get; private set; }
    private Guid _trainingCategoryId;
    
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

    public virtual ICollection<LearningTopicsEntity> LearningTopics { get; private set; } 

    #endregion
}