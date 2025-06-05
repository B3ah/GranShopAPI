using GranShopAPI.Data;
using GranShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GranShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController(AppDbContext db) : ControllerBase
    {
        private readonly AppDbContext _db = db;

        [HttpGet]
        public IActionResult Get() {
            var produtos = _db.Produtos
                .Include(c => c.Categoria)
                .ToList();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            var produto = _db.Produtos
                .Include(c => c.Categoria)
                .FirstOrDefault(p => p.Id == id);
            if (produto == null)
                return NotFound();
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Produto informado com problemas");
            _db.Produtos.Add(produto);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), produto.Id, new { produto });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid || id != produto.Id)
                return BadRequest("Produto informado com problemas");
            _db.Produtos.Update(produto);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _db.Produtos.Find(id);
            if (produto == null)
                return NotFound("Produto não encontrado!");
            _db.Produtos.Remove(produto);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
