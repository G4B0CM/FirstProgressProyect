using System.Diagnostics.CodeAnalysis;

namespace FirstProgressProyect.Models
{
    public class Admin : User
    {
        [AllowNull]
        public int CompetencesCreated { get; set; }
        public ICollection<Competence>? CreatedCompetences { get; set; }
    }
}
