using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiCultiChat.App.Domain.Entities;

namespace MultiCultiChat.App.Domain.EntityConfig;

public class ChatConfig : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.ChatUsers)
            .WithOne(c => c.Chat)
            .HasForeignKey(c => c.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.UnreadMessages)
            .WithOne(c => c.Chat)
            .HasForeignKey(c => c.ChatId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}