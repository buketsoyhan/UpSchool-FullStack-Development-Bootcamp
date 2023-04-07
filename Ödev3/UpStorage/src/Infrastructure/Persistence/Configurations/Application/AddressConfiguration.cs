using Domain.Entities;
using Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            //Address Type enum olduğu için veritabanına yazarken int'e çeviriyor kodda yine enum olarak kullanabiliyoruz.
            builder.Property(x => x.AddressType).IsRequired();
            builder.Property(x => x.AddressType).HasConversion<int>();

            // Relationships
            builder.HasOne<User>().WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
