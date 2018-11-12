using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Services;
using Newtonsoft.Json;

namespace Dashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssuntosChamadoController : ControllerBase
    {
        private readonly IAssuntoChamadoService _assuntoChamadoService;

        public AssuntosChamadoController(IAssuntoChamadoService assuntoChamadoService)
        {
            _assuntoChamadoService = assuntoChamadoService;
        }

        [HttpGet]
        public IEnumerable<AssuntoChamado> GetAll()
        {
            return _assuntoChamadoService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            AssuntoChamado assuntoChamado = _assuntoChamadoService.GetById(id);

            if (assuntoChamado == null)
            {
                return NotFound();
            }

            return Ok(assuntoChamado);
        }

        [HttpPut]
        public IActionResult Update([FromBody] AssuntoChamado assuntoChamado)
        {
            bool update = _assuntoChamadoService.Update(assuntoChamado);

            if(!update)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Add([FromBody] AssuntoChamado assuntoChamado)
        {
            assuntoChamado = _assuntoChamadoService.Add(assuntoChamado);

            if (assuntoChamado == null)
            {
                return NotFound();
            }

            return Ok(assuntoChamado);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            AssuntoChamado assuntoChamado = _assuntoChamadoService.GetById(id);

            if (assuntoChamado == null)
            {
                return NotFound();
            }

            bool remove = _assuntoChamadoService.Remove(assuntoChamado);

            if (!remove)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost, Route("valid")]
        public IActionResult Valid([FromBody] Dictionary<string, string> assuntoChamadoDictionary)
        {
            AssuntoChamado assuntoChamado = _assuntoChamadoService.Valid(assuntoChamadoDictionary);

            if (assuntoChamado == null)
            {
                return NotFound(_assuntoChamadoService.GetMessage());
            }

            return Ok(assuntoChamado);
        }
    }
}