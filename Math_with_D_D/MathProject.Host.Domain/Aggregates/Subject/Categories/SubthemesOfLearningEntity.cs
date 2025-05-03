using MathProject.Host.Domain.Common;

namespace MathProject.Host.Domain.Aggregates.Subject;

/// <summary>
/// Подтемы обучения (подпункты)
/// Прямоугольный треугольник
/// </summary>
public class SubthemesOfLearningEntity : Entity
{
    public SubthemesOfLearningEntity() { }
    
    public SubthemesOfLearningEntity(string name, Guid learningTopicsId, int displayOrder)
    {
        _name = name;
        _learningTopicsId = learningTopicsId;
        _displayOrder = displayOrder;
    }

    /// <summary>
    /// Название
    /// </summary>
    public string Name => _name;
    private string _name;
    
    public virtual LearningTopicsEntity LearningTopicsEntity { get; private set; }
    private Guid _learningTopicsId;

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
}