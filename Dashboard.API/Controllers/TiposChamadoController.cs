using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Services;

namespace Dashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposChamadoController : ControllerBase
    {
        private readonly ITipoChamadoService _tipoChamadoService;

        public TiposChamadoController(ITipoChamadoService tipoChamadoService)
        {
            _tipoChamadoService = tipoChamadoService;
        }

        [HttpGet]
        public IEnumerable<TipoChamado> GetAll()
        {
            return _tipoChamadoService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            TipoChamado tipoChamado = _tipoChamadoService.GetById(id);

            if (tipoChamado == null)
            {
                return NotFound();
            }

            return Ok(tipoChamado);
        }

        [HttpPut]
        public IActionResult Update([FromBody] TipoChamado tipoChamado)
        {
            bool update = _tipoChamadoService.Update(tipoChamado);

            if(!update)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Add([FromBody] TipoChamado tipoChamado)
        {
            tipoChamado = _tipoChamadoService.Add(tipoChamado);

            if (tipoChamado == null)
            {
                return NotFound();
            }

            return Ok(tipoChamado);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            TipoChamado tipoChamado = _tipoChamadoService.GetById(id);

            if (tipoChamado == null)
            {
                return NotFound();
            }

            bool remove = _tipoChamadoService.Remove(tipoChamado);

            if (!remove)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost, Route("valid")]
        public IActionResult Valid([FromBody] Dictionary<string, string> tipoChamadoDictionary)
        {
            TipoChamado tipoChamado = _tipoChamadoService.Valid(tipoChamadoDictionary);

            if (tipoChamado == null)
            {
                return NotFound(_tipoChamadoService.GetMessage());
            }

            return Ok(tipoChamado);
        }
    }
}