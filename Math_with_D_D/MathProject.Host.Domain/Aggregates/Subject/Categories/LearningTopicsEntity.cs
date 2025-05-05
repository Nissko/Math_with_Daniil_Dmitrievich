using MathProject.Host.Domain.Common;

namespace MathProject.Host.Domain.Aggregates.Subject.Categories;

/// <summary>
/// Темы обучения
/// 1. Простейшие текстовые задачи и тд
/// </summary>
public class LearningTopicsEntity : Entity
{
    public LearningTopicsEntity()
    {
        SubthemesOfLearnings = new HashSet<SubthemesOfLearningEntity>();
    }

    public LearningTopicsEntity(string name, Guid directionOfTrainingId, int displayOrder) : this()
    {
        _name = name;
        _directionOfTrainingId = directionOfTrainingId;
        _displayOrder = displayOrder;
    }

    /// <summary>
    /// Название
    /// </summary>
    public string Name => _name;
    private string _name;
    
    /// <summary>
    /// Направление обучения
    /// </summary>
    public virtual DirectionOfTrainingEntity DirectionOfTraining { get; private set; }
    private Guid _directionOfTrainingId;
    
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

    public virtual ICollection<SubthemesOfLearningEntity> SubthemesOfLearnings { get; private set; } 

    #endregion
}