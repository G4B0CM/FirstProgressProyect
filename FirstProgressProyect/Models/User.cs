using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstProgressProyect.Models
{
    abstract public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo Contraseña es obligatorio")]
        [StringLength(50)]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        [PasswordPropertyText]
        [Compare("Password",ErrorMessage ="Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Phone(ErrorMessage ="El formato del teléfono no es válido")]
        public string phonenumber { get; set; }

    }
}
