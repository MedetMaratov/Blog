using BlogEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEngine.Persistence.Config
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(blog => blog.Name)
                .IsRequired()
                .HasMaxLength(MaxLengthConstants.BlogName);
            builder.Property(blog => blog.Description)
                .HasMaxLength(MaxLengthConstants.BlogDescription);
        }
    }
}
