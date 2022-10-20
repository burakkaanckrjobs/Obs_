namespace ObsProject.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public int CityId { get; set; }
        public İlceler İlcelers { get; set; }
        public string Grup { get; set; }
        public List<TeacherStudens> TeacherStudens { get; set; }
        public List<StudentHobby> StudentHobbies { get; set; }
    }
}
