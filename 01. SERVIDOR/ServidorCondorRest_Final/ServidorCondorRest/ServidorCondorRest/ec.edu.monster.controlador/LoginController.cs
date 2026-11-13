using Microsoft.AspNetCore.Mvc;
using ServidorCondorRest.ec.edu.monster.modelo;

namespace ServidorCondorRest.ec.edu.monster.controlador
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AerolineasCondorContext _context;

        public LoginController(AerolineasCondorContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == login.Email && u.Contraseña == login.Contraseña);
            if (usuario == null)
                return Unauthorized("Usuario o contraseña incorrectos");

            return Ok(new
            {
                usuario.IdUsuario,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Email
            });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Contraseña { get; set; }
    }
}