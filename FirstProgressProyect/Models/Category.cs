using System.ComponentModel.DataAnnotations;

namespace FirstProgressProyect.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public ICollection<Competence>? Competences { get; set; }
    }
}
