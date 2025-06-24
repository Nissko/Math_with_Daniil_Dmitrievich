using MathProject.Host.Domain.Aggregates.Subject.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathProject.Host.Infrastructure.Configurations.Subject.Categories;

internal class LearningTopicsConfiguration : IEntityTypeConfiguration<LearningTopicsEntity>
{
    public void Configure(EntityTypeBuilder<LearningTopicsEntity> builder)
    {
        builder.ToTable("LearningTopics");
        builder.HasKey(x => x.Id);

        builder
            .Property<string>("_number")
            .HasColumnName("Number")
            .IsRequired();
        
        builder
            .Property<string>("_name")
            .HasColumnName("Name")
            .IsRequired();

        #region Опции управления

        builder
            .Property<bool>("_isVisible")
            .HasColumnName("IsVisible")
            .HasDefaultValue(false);

        builder
            .Property<int>("_displayOrder")
            .HasColumnName("DisplayOrder")
            .IsRequired();

        #endregion

        //One To Many (Один-ко-Многим)
        builder.HasOne(c => c.DirectionOfTraining)
            .WithMany(y => y.LearningTopics)
            .HasForeignKey("_directionOfTrainingId")
            .OnDelete(DeleteBehavior.SetNull);
    }
}