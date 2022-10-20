using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ObsProject.Models;

namespace ObsProject.Configuration
{
    public class TeacherStudentsConfiguration : IEntityTypeConfiguration<TeacherStudens>
    {
        public void Configure(EntityTypeBuilder<TeacherStudens> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Students).WithMany(x => x.TeacherStudens).HasForeignKey(x => x.StudentId);
            builder.HasOne(x => x.ClassTeachers).WithMany(x => x.TeacherStudens).HasForeignKey(x => x.ClasssTeacherId);
            builder.HasOne(x => x.GuideTeachers).WithMany(x => x.TeacherStudensGuide).HasForeignKey(x => x.GuideTeacherId);
        }
    }
}
