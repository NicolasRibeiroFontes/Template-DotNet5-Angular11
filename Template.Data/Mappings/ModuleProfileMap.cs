using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.Domain.Entities;

namespace Template.Data.Mappings
{
	public class ModuleProfileMap : IEntityTypeConfiguration<ModuleProfile>
    {
        public void Configure(EntityTypeBuilder<ModuleProfile> builder)
        {
            builder.HasKey(key => new { key.ModuleId, key.ProfileId });
        }
    }
}
