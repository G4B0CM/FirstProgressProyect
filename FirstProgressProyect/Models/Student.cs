namespace FirstProgressProyect.Models
{
    public class Student : User
    {
        public int Age { get; set; }
        public int Birthday { get; set; }
        public int NumCompletedCompetences { get; set; }
        public ICollection<StudentCompetence>? StudentCompetences { get; set; }
    }
}
