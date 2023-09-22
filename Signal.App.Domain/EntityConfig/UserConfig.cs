using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Signal.App.Domain.Entities;

namespace Signal.App.Domain.EntityConfig;

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
    }
}