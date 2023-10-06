using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiCultiChat.App.Domain.Entities;

namespace MultiCultiChat.App.Domain.EntityConfig;

public class UnreadMessageConfig: IEntityTypeConfiguration<UnreadChat>
{
    public void Configure(EntityTypeBuilder<UnreadChat> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.User)
            .WithMany(c => c.UnreadMessages)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(c => c.Chat)
            .WithMany(c => c.UnreadMessages)
            .HasForeignKey(c => c.ChatId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}