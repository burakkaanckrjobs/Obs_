using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObsProject.Models;

namespace ObsProject.Configuration
{
    public class StudentHobbyConfiguration : IEntityTypeConfiguration<StudentHobby>
    {
        public void Configure(EntityTypeBuilder<StudentHobby> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Students).WithMany(x => x.StudentHobbies).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.Hobby).WithMany(x => x.StudentHobbies).HasForeignKey(x => x.HobbyId);
        }
    }
}
