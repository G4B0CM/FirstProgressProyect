using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProgressProyect.Models
{
    public class StudentCompetence
    {
        [Key, Column(Order = 0)]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        [Key, Column(Order = 1)]
        public int CompetenceId { get; set; }
        public Competence? Competence { get; set; }
        public DateOnly DateOfParticipation { get; set; }
    }
}
