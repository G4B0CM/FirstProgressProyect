using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstProgressProyect.Controllers
{
    public class AuthController : Controller
    {


        private readonly ApplicationDbContext _context;
        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await _context.Logins.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("Rol", user.Rol.ToString());
                HttpContext.Session.SetString("UserName", user.UserName);
                if (user.Rol == Models.Rol.Admin)
                {
                    return RedirectToAction("Home", "Admins");
                }
                else
                {
                    return RedirectToAction("Home", "Students");
                }

            }
            ViewBag.Error = "Usuario o Contraseña Incorrectos";
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
