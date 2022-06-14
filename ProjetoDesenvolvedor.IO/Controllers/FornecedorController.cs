using Microsoft.AspNetCore.Mvc;
using ProjetoDesenvolvedor.IO.Data.Dtos.Fornecedor;
using ProjetoDesenvolvedor.IO.Interfaces;
using System.Threading.Tasks;

namespace ProjetoDesenvolvedor.IO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : BaseController
    {

        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService, INotificador notificador) : base(notificador)
        {
            _fornecedorService = fornecedorService;

        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await _fornecedorService.ObterTodos();
            if (resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var resultado = await _fornecedorService.ObterPorId(id);
            if (resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] CreateFornecedorDto dados)
        {

            var resultado = await _fornecedorService.Adicionar(dados);

            if (resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var resultado = await _fornecedorService.Deletar(id);

            if (resultado.IsFailed || resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado.WithSuccess("Fornecedor deletado com sucesso!"));
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] UpdateFornecedorDto dados)
        {
            var resultado = await _fornecedorService.Atualizar(dados);

            if (resultado.IsFailed || resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado.WithSuccess("Fornecedor atualizado com sucesso!"));
        }
    }
}
