using ProjetoDesenvolvedor.IO.Enum;
using System;
using System.Text.Json.Serialization;

namespace ProjetoDesenvolvedor.IO.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; private set; }

        public double Valor { get; private set; }

        public EAtivoInativo Situacao { get; private set; }

        public string Descricao { get; private set; }

        public DateTime DataCadastro { get; private set; } = DateTime.Now;

        public string Imagem { get; private set; }

        public int IdFornecedor { get; private set; }

        [JsonIgnore]
        public virtual Fornecedor Fornecedor { get; private set; }

        public Produto(string nome, double valor, EAtivoInativo situacao, string descricao, string imagem, int idFornecedor)
        {
            Nome = nome;
            Valor = valor;
            Situacao = situacao;
            Descricao = descricao;
            Imagem = imagem;
            IdFornecedor = idFornecedor;
        }

        public Produto(string nome, double valor, EAtivoInativo situacao, string descricao, string imagem)
        {
            Nome = nome;
            Valor = valor;
            Situacao = situacao;
            Descricao = descricao;
            Imagem = imagem;
        }

        public Produto()
        {

        }
    }
}
