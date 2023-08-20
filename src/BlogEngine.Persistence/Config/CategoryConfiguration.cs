using BlogEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEngine.Persistence.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(category => category.Name)
                .IsRequired()
                .HasMaxLength(MaxLengthConstants.CategoryName);
            builder.HasIndex(category => category.Name)
            .IsUnique();
        }
    }
}
