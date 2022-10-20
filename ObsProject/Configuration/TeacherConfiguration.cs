using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObsProject.Models;

namespace ObsProject.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teachers>
    {
        public void Configure(EntityTypeBuilder<Teachers> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
