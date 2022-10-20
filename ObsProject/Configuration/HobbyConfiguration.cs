using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObsProject.Models;

namespace ObsProject.Configuration
{
    public class HobbyConfiguration : IEntityTypeConfiguration<Hobby>
    {
        public void Configure(EntityTypeBuilder<Hobby> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
