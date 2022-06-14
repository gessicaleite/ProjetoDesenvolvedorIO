using ProjetoDesenvolvedor.IO.Enum;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjetoDesenvolvedor.IO.Entities
{
    public class Fornecedor : BaseEntity
    {
        public string Nome { get; private set; }

        public string Documento { get; private set; }

        public EAtivoInativo Situacao { get; private set; }

        public ETipoCliente TipoPessoa { get; private set; }

        [JsonIgnore]
        public virtual Endereco Endereco { get; private set; }

        [JsonIgnore]
        public virtual List<Produto> Produtos { get; private set; }

        public Fornecedor(string nome, string documento, EAtivoInativo situacao, ETipoCliente tipoPessoa)
        {
            Nome = nome;
            Documento = documento;
            Situacao = situacao;
            TipoPessoa = tipoPessoa;
        }
    }
}
