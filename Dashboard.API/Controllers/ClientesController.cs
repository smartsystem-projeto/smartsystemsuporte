using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Services;

namespace Dashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService= clienteService;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetAll()
        {
            return _clienteService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Cliente cliente = _clienteService.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Cliente cliente)
        {
            bool update = _clienteService.Update(cliente);

            if(!update)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Cliente cliente)
        {
            cliente = _clienteService.Add(cliente);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            Cliente cliente = _clienteService.GetById(id);

            if (cliente == null)
            {
                return NotFound();
            }

            bool remove = _clienteService.Remove(cliente);

            if (!remove)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost, Route("valid")]
        public IActionResult Valid([FromBody] Dictionary<string, string> clienteDictionary)
        {
            Cliente cliente = _clienteService.Valid(clienteDictionary);

            if (cliente == null)
            {
                return NotFound(_clienteService.GetMessage());
            }

            return Ok(cliente);
        }
    }
}