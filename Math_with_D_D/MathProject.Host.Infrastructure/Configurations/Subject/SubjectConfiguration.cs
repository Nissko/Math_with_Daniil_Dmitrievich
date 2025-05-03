using MathProject.Host.Domain.Aggregates.Subject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MathProject.Host.Infrastructure.Configurations.Subject;

internal class SubjectConfiguration : IEntityTypeConfiguration<SubjectEntity>
{
    public void Configure(EntityTypeBuilder<SubjectEntity> builder)
    {
        builder.ToTable("Subjects");
        builder.HasKey(x => x.Id);
        
        builder
            .Property<string>("_name")
            .HasColumnName("Name")
            .IsRequired();
    }
}