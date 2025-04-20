using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameAPI.Data;
using VideoGameAPI.Models;

namespace VideoGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly VideoGameAPIDbContext _context;
        public ProdutoController(VideoGameAPIDbContext context) 
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<List<ProdutoModel>> BuscarProdutos()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProdutoModel> BuscarProdutoPorId(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult<ProdutoModel> CriarProduto(ProdutoModel produtoModel)
        {
            if(produtoModel == null)
            {
                return BadRequest("Produto inválido");
            }

            _context.Produtos.Add(produtoModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarProdutoPorId), new { id = produtoModel.Id }, produtoModel); 
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<ProdutoModel> EditarProduto(ProdutoModel produtoModel, int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            produto.Nome = produtoModel.Nome;
            produto.Descricao = produtoModel.Descricao;
            produto.QuantidadeEstoque = produtoModel.QuantidadeEstoque;
            produto.CodigoDeBarras = produtoModel.CodigoDeBarras;
            produto.Marca = produtoModel.Marca;


            _context.Produtos.Update(produto);
            _context.SaveChanges(); 

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<ProdutoModel> DeletarProduto(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
