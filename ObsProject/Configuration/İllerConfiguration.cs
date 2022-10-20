using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObsProject.Models;

namespace ObsProject.Configuration
{
    public class İllerConfiguration : IEntityTypeConfiguration<İller>
    {
        public void Configure(EntityTypeBuilder<İller> builder)
        {
            builder.HasKey(x => x.id);
        }
    }
}
