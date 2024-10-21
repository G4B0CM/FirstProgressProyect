namespace FirstProgressProyect.Models
{
    public class Admin : User
    {
        public int CompetencesCreated { get; set; }
        public ICollection<Competence> CreatedCompetences { get; set; }
    }
}
