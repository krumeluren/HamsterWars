using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;
public class HamsterMap
{
    public HamsterMap(EntityTypeBuilder<Hamster> entityBuilder)
    {
        entityBuilder.HasKey(p => p.Id);
        entityBuilder.Property(p => p.Name).IsRequired().HasMaxLength(20);
        entityBuilder.Property(p => p.Age).IsRequired();
        entityBuilder.Property(p => p.FavFood).IsRequired().HasMaxLength(30);
        entityBuilder.Property(p => p.Loves).IsRequired().HasMaxLength(100);    
        entityBuilder.Property(p => p.ImgName).IsRequired().HasMaxLength(100);
    }
}
