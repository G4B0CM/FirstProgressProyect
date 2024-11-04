using Azure.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstProgressProyect.Models
{
    public enum Rol
    {
        Admin = 1,
        Student = 2
    }
    public class Login

    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo User_Name es obligatorio")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "El campo Password es obligatorio")]
        [StringLength(50)]
        [PasswordPropertyText]
        public string Password { get; set; }

        public Rol Rol { get; set; }



    }
}
