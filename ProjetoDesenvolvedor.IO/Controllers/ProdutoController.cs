using Microsoft.AspNetCore.Mvc;
using ProjetoDesenvolvedor.IO.Data.Dtos.Produto;
using ProjetoDesenvolvedor.IO.Interfaces;
using System.Threading.Tasks;

namespace ProjetoDesenvolvedor.IO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _produtoService;


        public ProdutoController(IProdutoService produtoService, INotificador notificador) : base(notificador)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await _produtoService.ObterTodos();
            if (resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var resultado = await _produtoService.ObterPorId(id);

            if (resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] CreateProdutoDto dados)
        {
            var resultado = await _produtoService.Adicionar(dados);

            if (resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var resultado = await _produtoService.Deletar(id);

            if (resultado.IsFailed || resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado.WithSuccess("Produto deletado com sucesso!"));
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] UpdateProdutoDto dados)
        {
            var resultado = await _produtoService.Atualizar(dados);
            if (resultado.IsFailed || resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado.WithSuccess("Produto atualizado com sucesso!"));
        }

    }
}
