using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            //Id
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            //Title
            builder.Property(x => x.Title).IsRequired(false);
            builder.Property(x => x.Title).HasMaxLength(150);

            //Content
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Content).HasMaxLength(150);

            //User Id
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.UserId).HasMaxLength(150);

            builder.ToTable("Notes");

            //Relationships
            //builder.HasOne<Note>(x => x.Note)
            //    .WithMany(x => x.NoteCategories)
            //    .HasForeignKey();
        }
    }
}
