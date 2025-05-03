using MathProject.Host.Domain.Aggregates.Subject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathProject.Host.Infrastructure.Configurations.Subject.Categories;

public class SubthemesOfLearningConfiguration : IEntityTypeConfiguration<SubthemesOfLearningEntity>
{
    public void Configure(EntityTypeBuilder<SubthemesOfLearningEntity> builder)
    {
        builder.ToTable("SubthemeOfLearnings");
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
        builder.HasOne(c => c.LearningTopicsEntity)
            .WithMany(y => y.SubthemesOfLearnings)
            .HasForeignKey("_learningTopicsId")
            .OnDelete(DeleteBehavior.SetNull);
    }
}