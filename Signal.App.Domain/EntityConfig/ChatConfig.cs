using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Signal.App.Domain.Entities;

namespace Signal.App.Domain.EntityConfig;

public class ChatConfig : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.ChatUsers)
            .WithOne(c => c.Chat)
            .HasForeignKey(c => c.ChatId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}