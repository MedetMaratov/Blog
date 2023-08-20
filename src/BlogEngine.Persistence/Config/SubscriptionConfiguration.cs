using BlogEngine.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEngine.Persistence.Config
{
    public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            builder
                .HasOne(subscription => subscription.Blog)
                .WithMany(blog => blog.Subscriptions)
                .HasForeignKey(subscription => subscription.BlogId);
        }
    }
}
