using AutoMapper;
using ProjetoDesenvolvedor.IO.Data.Dtos.Produto;
using ProjetoDesenvolvedor.IO.Entities;

namespace ProjetoDesenvolvedor.IO.Services
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<UpdateProdutoDto, Produto>().ReverseMap();
            CreateMap<CreateProdutoDto, Produto>();
            CreateMap<Produto, BaseProdutoDto>();
            CreateMap<Produto, ReadProdutoDto>()
                .ForMember(
                    fornecedor => fornecedor.FornecedorDto, map => map
                    .MapFrom(src => src.Fornecedor))
                .ForPath(
                    fornecedor => fornecedor.FornecedorDto.Nome, map => map
                    .MapFrom(src => src.Fornecedor.Nome))
                .ForPath(
                    fornecedor => fornecedor.FornecedorDto.Documento, map => map
                    .MapFrom(src => src.Fornecedor.Documento))
                .ForPath(
                    fornecedor => fornecedor.FornecedorDto.Situacao, map => map
                    .MapFrom(src => src.Fornecedor.Situacao))
                .ForPath(
                    fornecedor => fornecedor.FornecedorDto.TipoPessoa, map => map
                    .MapFrom(src => src.Fornecedor.TipoPessoa));
        }
    }
}
