using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProgressProyect.Models
{
    [PrimaryKey(nameof(StudentId), nameof(CompetenceId))]
    public class StudentCompetence
    {
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        public int CompetenceId { get; set; }
        public Competence? Competence { get; set; }

        public DateOnly DateOfParticipation { get; set; }
    }
}
