using Microsoft.AspNetCore.Mvc;
using ProjetoDesenvolvedor.IO.Data.Dtos.Endereco;
using ProjetoDesenvolvedor.IO.Interfaces;
using System.Threading.Tasks;

namespace ProjetoDesenvolvedor.IO.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : BaseController
    {
        private readonly IEnderecoService _enderecoService;


        public EnderecoController(IEnderecoService enderecoService, INotificador notificador) : base(notificador)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var resultado = await _enderecoService.ObterTodos();

            if (resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var resultado = await _enderecoService.ObterPorId(id);

            if (resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] CreateEnderecoDto dadosDto)
        {
            var resultado = await _enderecoService.Adicionar(dadosDto);

            if (resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var resultado = await _enderecoService.Deletar(id);

            if (resultado.IsFailed || resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado.WithSuccess("Endereço deletado com sucesso!"));
        }


        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] UpdateEnderecoDto dados)
        {
            var resultado = await _enderecoService.Atualizar(dados);
            if (resultado.IsFailed || resultado is null)
            {
                return VerificarNotificacoes();
            }
            return Ok(resultado.WithSuccess("Endereço atualizado com sucesso!"));
        }
    }
}
