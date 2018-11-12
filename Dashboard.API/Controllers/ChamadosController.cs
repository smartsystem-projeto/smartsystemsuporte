using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Services;

namespace Dashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChamadosController : ControllerBase
    {
        private readonly IChamadoService _chamadoService;

        public ChamadosController(IChamadoService chamadoService)
        {
            _chamadoService = chamadoService;
        }

        [HttpGet]
        public IEnumerable<Chamado> GetAll()
        {
            return _chamadoService.GetAll();
        }

        [HttpGet("emaberto/cliente/{clienteId}")]
        public IEnumerable<Chamado> ObterTodosEmAbertoPorClienteId([FromRoute] int clienteId)
        {
            return _chamadoService.ObterTodosEmAbertoPorClienteId(clienteId);
        }

        [HttpGet("emaberto/funcionario/{funcionarioId}")]
        public IEnumerable<Chamado> ObterTodosEmAbertoPorFuncionarioId([FromRoute] int funcionarioId)
        {
            return _chamadoService.ObterTodosEmAbertoPorFuncionarioId(funcionarioId);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Chamado chamado = _chamadoService.GetById(id);

            if (chamado == null)
            {
                return NotFound();
            }

            return Ok(chamado);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Chamado chamado)
        {
            bool update = _chamadoService.Update(chamado);

            if(!update)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("{id}/funcionario/{funcionarioId}")]
        public IActionResult AtualizarFuncionarioIdPorId([FromRoute] int id, int funcionarioId)
        {
            _chamadoService.AtualizarFuncionarioIdPorId(id, funcionarioId);

            if (!_chamadoService.IsSuccessStatus())
            {
                return NotFound(_chamadoService.GetMessage());
            }

            return Ok(_chamadoService.GetMessage());
        }

        [HttpGet("{id}/status/{status}")]
        public IActionResult AtualizarStatusPorId([FromRoute] int id, string status)
        {
            _chamadoService.AtualizarStatusPorId(id, status);

            if (!_chamadoService.IsSuccessStatus())
            {
                return NotFound(_chamadoService.GetMessage());
            }

            return Ok(_chamadoService.GetMessage());
        }

        [HttpPost]
        public IActionResult Add([FromBody] Chamado chamado)
        {
            chamado = _chamadoService.Add(chamado);

            if (chamado == null)
            {
                return NotFound();
            }

            return Ok(chamado);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            Chamado chamado = _chamadoService.GetById(id);

            if (chamado == null)
            {
                return NotFound();
            }

            bool remove = _chamadoService.Remove(chamado);

            if (!remove)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}