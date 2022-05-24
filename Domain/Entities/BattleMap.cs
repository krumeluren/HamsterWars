using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities;
public class BattleMap
{
    public BattleMap(EntityTypeBuilder<Battle> entityBuilder)
    {
        entityBuilder.HasKey(p => p.Id);
    }
}
