using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiCultiChat.App.Domain.Entities;

namespace MultiCultiChat.App.Domain.EntityConfig;

internal sealed class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.ChatUsers)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Messages)
            .WithOne(c => c.Sender)
            .HasForeignKey(c => c.SenderId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(c => c.UnreadMessages)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}