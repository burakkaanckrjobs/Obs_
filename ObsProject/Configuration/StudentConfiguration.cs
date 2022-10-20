using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObsProject.Models;

namespace ObsProject.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.İlcelers).WithMany(x => x.Students).HasForeignKey(x => x.CityId);
        }
    }
}
