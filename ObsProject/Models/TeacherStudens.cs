namespace ObsProject.Models
{
    public class TeacherStudens
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Students Students { get; set; }
        public int GuideTeacherId { get; set; }
        public Teachers GuideTeachers { get; set; }
        public int ClasssTeacherId { get; set; }
        public Teachers ClassTeachers { get; set; }
    }
}
