using ObsProject.Models;

namespace ObsProject.ViewModel
{
    public class StudentVM
    {
        public StudentVM()
        {
            İllers = new List<İller>();
            İlcelers = new List<İlceler>();
            Ogrencis = new List<Students>();
            Ogretmens = new List<Teachers>();
            StudentModel=new StudentModel();
            Hobbies = new List<Hobby>();
        }
        public List<İller> İllers { get; set; }
        public List<İlceler> İlcelers { get; set; }
        public List<Students> Ogrencis { get; set; }
        public List<Teachers> Ogretmens { get; set; }
        public StudentModel StudentModel { get; set; }
        public List<Hobby> Hobbies { get; set; }
    }
}
