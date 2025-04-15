using MathProject.Host.Domain.Common;

namespace MathProject.Host.Domain.Aggregates.Subject;

/// <summary>
/// Темы обучения
/// 1. Простейшие текстовые задачи и тд
/// </summary>
public class LearningTopics : Entity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name => _name;
    private string _name;
    
    /// <summary>
    /// Направление обучения
    /// </summary>
    public DirectionOfTrainingEntity DirectionOfTraining { get; private set; }
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
    public string DisplayOrder => _displayOrder;
    private string _displayOrder;

    #endregion
}