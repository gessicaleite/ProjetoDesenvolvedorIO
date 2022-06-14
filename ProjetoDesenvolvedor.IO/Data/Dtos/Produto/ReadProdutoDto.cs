using ProjetoDesenvolvedor.IO.Data.Dtos.Fornecedor;
using ProjetoDesenvolvedor.IO.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDesenvolvedor.IO.Data.Dtos.Produto
{
    public class ReadProdutoDto
    {
        public string Nome { get; private set; }

        public double Valor { get; private set; }

        public EAtivoInativo Situacao { get; private set; }

        public string Descricao { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public string Imagem { get; private set; }

        public int IdFornecedor { get; private set; }

        [Display(Name = "Fornecedor")]

        public BaseFornecedorDto FornecedorDto { get; private set; }
    }
}
