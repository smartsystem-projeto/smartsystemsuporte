using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Services;

namespace Dashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosicionamentosChamadoController : ControllerBase
    {
        private readonly IPosicionamentoChamadoService _posicionamentoChamadoService;

        public PosicionamentosChamadoController(IPosicionamentoChamadoService posicionamentoChamadoService)
        {
            _posicionamentoChamadoService = posicionamentoChamadoService;
        }

        [HttpGet]
        public IEnumerable<PosicionamentoChamado> GetAll()
        {
            return _posicionamentoChamadoService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            PosicionamentoChamado posicionamentoChamado = _posicionamentoChamadoService.GetById(id);

            if (posicionamentoChamado == null)
            {
                return NotFound();
            }

            return Ok(posicionamentoChamado);
        }

        [HttpPut]
        public IActionResult Update([FromBody] PosicionamentoChamado posicionamentoChamado)
        {
            bool update = _posicionamentoChamadoService.Update(posicionamentoChamado);

            if(!update)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Add([FromBody] PosicionamentoChamado posicionamentoChamado)
        {
            posicionamentoChamado = _posicionamentoChamadoService.Add(posicionamentoChamado);

            if (posicionamentoChamado == null)
            {
                return NotFound();
            }

            return Ok(posicionamentoChamado);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            PosicionamentoChamado posicionamentoChamado = _posicionamentoChamadoService.GetById(id);

            if (posicionamentoChamado == null)
            {
                return NotFound();
            }

            bool remove = _posicionamentoChamadoService.Remove(posicionamentoChamado);

            if (!remove)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost, Route("valid")]
        public IActionResult Valid([FromBody] Dictionary<string, string> posicionamentoChamadoDictionary)
        {
            PosicionamentoChamado posicionamentoChamado  = _posicionamentoChamadoService.Valid(posicionamentoChamadoDictionary);

            if (posicionamentoChamado == null)
            {
                return NotFound(_posicionamentoChamadoService.GetMessage());
            }

            return Ok(posicionamentoChamado);
        }
    }
}