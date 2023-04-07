using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            //Relationships
            builder.HasOne<Note>(x => x.Note)
                .WithMany(x => x.NoteCategories)
                .HasForeignKey();
        }
    }
}
