namespace MathProject.Host.Domain.Aggregates.Subject;

/// <summary>
/// Подтемы обучения (подпункты)
/// Прямоугольный треугольник
/// </summary>
public class SubthemesOfLearningEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name => _name;
    private string _name;
    
    public LearningTopicsEntity LearningTopicsEntity { get; private set; }
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
    public string DisplayOrder => _displayOrder;
    private string _displayOrder;

    #endregion
}