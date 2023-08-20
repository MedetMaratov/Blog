using BlogEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEngine.Persistence.Config
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(comment => comment.Content)
               .IsRequired()
               .HasMaxLength(MaxLengthConstants.CommentContent);
            builder.HasOne(category => category.Post)
               .WithMany(post => post.Comments)
               .HasForeignKey(comment => comment.PostId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
