using MathProject.Host.Domain.Aggregates.Subject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathProject.Host.Infrastructure.Configurations.Subject.Categories;

internal class DirectionOfTrainingConfiguration : IEntityTypeConfiguration<DirectionOfTrainingEntity>
{
    public void Configure(EntityTypeBuilder<DirectionOfTrainingEntity> builder)
    {
        builder.ToTable("DirectionOfTrainings");
        builder.HasKey(x => x.Id);

        builder
            .Property<string>("_name")
            .HasColumnName("Name")
            .IsRequired();
        
        builder
            .Property<DateTime>("_dateTrainingDir")
            .HasColumnName("Date")
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
        builder.HasOne(c => c.TrainingCategory)
            .WithMany(y=> y.DirectionOfTrainings)
            .HasForeignKey("_trainingCategoryId")
            .OnDelete(DeleteBehavior.SetNull);
    }
}