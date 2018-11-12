using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Services;

namespace Dashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionariosController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public IEnumerable<Funcionario> GetAll()
        {
            return _funcionarioService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Funcionario funcionario = _funcionarioService.GetById(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Funcionario funcionario)
        {
            bool update = _funcionarioService.Update(funcionario);

            if(!update)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Funcionario funcionario)
        {
            funcionario = _funcionarioService.Add(funcionario);

            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            Funcionario funcionario = _funcionarioService.GetById(id);

            if (funcionario == null)
            {
                return NotFound();
            }

            bool remove = _funcionarioService.Remove(funcionario);

            if (!remove)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost, Route("valid")]
        public IActionResult Valid([FromBody] Dictionary<string, string> funcionarioDictionary)
        {
            Funcionario funcionario = _funcionarioService.Valid(funcionarioDictionary);

            if (funcionario == null)
            {
                return NotFound(_funcionarioService.GetMessage());
            }

            return Ok(funcionario);
        }
    }
}