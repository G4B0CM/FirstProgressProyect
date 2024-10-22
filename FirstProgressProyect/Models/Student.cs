using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FirstProgressProyect.Models
{
    public class Student : User
    {
        [Range(18, 27)]
        public int Age { get; set; }
        public DateOnly Birthday { get; set; }
        [AllowNull]
        public int NumCompletedCompetences { get; set; }
        public ICollection<StudentCompetence>? StudentCompetences { get; set; }
    }
}
