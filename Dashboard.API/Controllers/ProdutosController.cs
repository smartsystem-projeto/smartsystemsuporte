using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Dashboard.Domain.Entities;
using Dashboard.Domain.Interfaces.Services;

namespace Dashboard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IEnumerable<Produto> GetAll()
        {
            return _produtoService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            Produto produto = _produtoService.GetById(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Produto produto)
        {
            bool update = _produtoService.Update(produto);

            if(!update)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Produto produto)
        {
            produto = _produtoService.Add(produto);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            Produto produto = _produtoService.GetById(id);

            if (produto == null)
            {
                return NotFound();
            }

            bool remove = _produtoService.Remove(produto);

            if (!remove)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost, Route("valid")]
        public IActionResult Valid([FromBody] Dictionary<string, string> produtoDictionary)
        {
            Produto produto = _produtoService.Valid(produtoDictionary);

            if (produto == null)
            {
                return NotFound(_produtoService.GetMessage());
            }

            return Ok(produto);
        }
    }
}