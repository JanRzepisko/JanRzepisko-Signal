using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiCultiChat.App.Domain.Entities;

namespace MultiCultiChat.App.Domain.EntityConfig;

public class ChatUserConfig : IEntityTypeConfiguration<ChatUser>
{
    public void Configure(EntityTypeBuilder<ChatUser> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.User)
            .WithMany(c => c.ChatUsers)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Chat)
            .WithMany(c => c.ChatUsers)
            .HasForeignKey(c => c.ChatId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}