using BlogEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEngine.Persistence.Config
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(post => post.Title)
                .IsRequired()
                .HasMaxLength(MaxLengthConstants.PostTitle);
            builder.Property(post => post.Content)
                .IsRequired()
                .HasMaxLength(MaxLengthConstants.PostContent);
            builder.HasOne(post => post.Blog)
               .WithMany(blog => blog.Posts)
               .HasForeignKey(post => post.BlogId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
