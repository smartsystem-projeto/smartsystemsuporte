using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Services;
using Dashboard.Domain.Services;

namespace Dashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Usuario usuario = _usuarioService.GetById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Usuario usuario)
        {
            bool update = _usuarioService.Update(usuario);

            if(!update)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Usuario usuario)
        {
            usuario = _usuarioService.Add(usuario);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            Usuario usuario = _usuarioService.GetById(id);

            if (usuario == null)
            {
                return NotFound();
            }

            bool remove = _usuarioService.Remove(usuario);

            if (!remove)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost, Route("valid")]
        public IActionResult Valid([FromBody] Dictionary<string, string> usuarioDictionary)
        {
            Usuario usuario = new Usuario();
            usuario = _usuarioService.Valid(usuarioDictionary);

            if (usuario == null)
            {
                return NotFound(_usuarioService.GetMessage());
            }

            return Ok(usuario);
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] Dictionary<string, string> loginDictionary)
        {
            Usuario usuario = _usuarioService.Login(loginDictionary);

            if (!_usuarioService.IsSuccessStatus())
            {;
                return NotFound(_usuarioService.GetMessage());
            }

            return Ok(usuario);
        }
    }
}