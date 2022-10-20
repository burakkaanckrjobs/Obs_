namespace ObsProject.Models
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Hobbys { get; set; }
        public List<StudentHobby> StudentHobbies { get; set; }
    }
}
