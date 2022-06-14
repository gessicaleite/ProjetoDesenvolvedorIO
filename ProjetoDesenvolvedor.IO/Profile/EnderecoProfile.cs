using AutoMapper;
using ProjetoDesenvolvedor.IO.Data.Dtos.Endereco;
using ProjetoDesenvolvedor.IO.Entities;

namespace ProjetoDesenvolvedor.IO.Services
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<UpdateEnderecoDto, Endereco>().ReverseMap();
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>()
                .ForMember(
                fornecedor => fornecedor.FornecedorDto, map => map
                .MapFrom(src => src.Fornecedor));
            CreateMap<Endereco, BaseEnderecoDto>();
        }
    }
}
