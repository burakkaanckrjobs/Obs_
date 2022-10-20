namespace ObsProject.Models
{
    public class Teachers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TeacherStudens> TeacherStudens { get; set; }
        public List<TeacherStudens> TeacherStudensGuide { get; set; }

    }
}
