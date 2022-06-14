using AutoMapper;
using FluentResults;
using ProjetoDesenvolvedor.IO.Data.Dtos.Produto;
using ProjetoDesenvolvedor.IO.Entities;
using ProjetoDesenvolvedor.IO.Interfaces;
using ProjetoDesenvolvedor.IO.Validation;
using System.Threading.Tasks;

namespace ProjetoDesenvolvedor.IO.Services
{
    public class ProdutoService : BaseService<Produto, ReadProdutoDto, CreateProdutoDto, UpdateProdutoDto, BaseProdutoDto>, IProdutoService
    {
        private readonly IFornecedorService _fornecedorService;
        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper, IFornecedorService fornecedorService, INotificador notificador) : base(produtoRepository, mapper, notificador)
        {
            _fornecedorService = fornecedorService;
        }

        public async override Task<ReadProdutoDto> Adicionar(CreateProdutoDto dadosDto)
        {
            var produto = _mapper.Map<Produto>(dadosDto);
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return null;

            var fornecedor = await _fornecedorService.ObterPorId(dadosDto.IdFornecedor);
            if (fornecedor is not null) return await base.Adicionar(dadosDto);

            Notificar($"Não existe fornecedor cadastrado para o id {dadosDto.IdFornecedor}");
            return null;
        }

        public async Task<Result> Atualizar(UpdateProdutoDto dados)
        {
            var produtoRepositorio = await _baseRepository.ObterEntidadePorId(dados.Id);
            if (produtoRepositorio is null)
            {
                Notificar($"Id {dados.Id} não cadastrado na base dados.");
                return Result.Fail("Id não encontrado.");
            }

            var fornecedorRepositorio = await _fornecedorService.ObterPorId(dados.IdFornecedor);
            if (fornecedorRepositorio is null) return Result.Fail("Fornecedor Id não encontrado.");

            var produto = _mapper.Map<Produto>(dados);
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return Result.Fail("Erro ao validar produto.");

            _mapper.Map(dados, produtoRepositorio);

            await _baseRepository.Atualizar(produtoRepositorio);
            return Result.Ok();
        }
    }
}
