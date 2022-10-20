namespace ObsProject.Models
{
    public class İlceler
    {
        public int id { get; set; }
        public string ilceadi { get; set; }
        public int sehirid { get; set; }
        public İller İller { get; set; }
        public List<Students> Students { get; set; }
    }
}
