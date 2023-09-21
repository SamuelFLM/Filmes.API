using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_Filmes.Context;
using WEBAPI_Filmes.Models;

namespace WEBAPI_Filmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {

        private readonly FilmeContext _context;
        public FilmeController(FilmeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_context.Filmes);
        }
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var filme = _context.Filmes.Find(id);
            if (filme == null)
                return NotFound();
            return Ok(filme);
        }
        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var filme = _context.Filmes.Where(x => x.Nome.Contains(nome));
            return Ok(filme);
        }
        [HttpGet("ObterPorCategoria")]
        public IActionResult ObterPorCategoria(string categoria){
            var filme = _context.Filmes.Where(x => x.Categoria == categoria);
            return Ok(filme);
        }
        [HttpGet("ObterPorNota")]
        public IActionResult ObterPorNota(int nota){
            var filme = _context.Filmes.Where(x => x.Nota == nota);
            return Ok(filme);
        }
        [HttpPost]
        public IActionResult CriarFilme(Filme filme)
        {
            _context.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = filme.Id }, filme);
        }
        [HttpPut("{id}")]
        public IActionResult AlterarFilme(int id,Filme _filme){
            var filme = _context.Filmes.Find(id);
            if (filme == null)
                return NotFound();
            filme.Nome = _filme.Nome;
            filme.Descricao = _filme.Descricao;
            filme.Categoria = _filme.Categoria;
            filme.Nota = _filme.Nota;
            _context.Update(filme);
            _context.SaveChanges();
            return Ok(filme);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarFilme(int id){
            var filme = _context.Filmes.Find(id);
            if (filme == null)
                return BadRequest();
            _context.Filmes.Remove(filme);
            _context.SaveChanges();
            return Ok();
        }
    }
}