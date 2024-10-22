using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProgressProyect.Models
{
    public class Competence
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public Category? Category { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public Admin? Admin { get; set; }
        public ICollection<StudentCompetence>? StudentCompetences { get; set; }
        public int NumParticipants { get; set; }
        public int MaxNumParticipants { get; set; }
        public int MinNumParticipants { get; set; }
        public DateTime Date {  get; set; }
        public DateTime MaxDateOfIncription { get; set; }

    }
}
