using MathProject.Host.Domain.Aggregates.Subject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathProject.Host.Infrastructure.Configurations.Subject.Categories;

internal class TrainingCategoryConfiguration : IEntityTypeConfiguration<TrainingCategoryEntity>
{
    public void Configure(EntityTypeBuilder<TrainingCategoryEntity> builder)
    {
        builder.ToTable("TrainingCategories");
        builder.HasKey(x => x.Id);

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
        builder.HasOne(c => c.Subject)
            .WithMany(y => y.TrainingCategories)
            .HasForeignKey("_subjectId")
            .OnDelete(DeleteBehavior.SetNull);
    }
}