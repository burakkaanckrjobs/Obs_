using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ObsProject.Models
{
    public class İlcelerConfiguration : IEntityTypeConfiguration<İlceler>
    {
        public void Configure(EntityTypeBuilder<İlceler> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasOne(x => x.İller).WithMany(x => x.İlcelers).HasForeignKey(x => x.sehirid);
        }
    }
}
