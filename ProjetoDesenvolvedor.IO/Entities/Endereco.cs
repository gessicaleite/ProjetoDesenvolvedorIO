using ProjetoDesenvolvedor.IO.Enum;
using System.Text.Json.Serialization;

namespace ProjetoDesenvolvedor.IO.Entities
{
    public class Endereco : BaseEntity
    {
        public string Rua { get; private set; }

        public int Numero { get; private set; }

        public string Cidade { get; private set; }

        public EUfEstado Estado { get; private set; }

        public int IdFornecedor { get; private set; }

        [JsonIgnore]
        public virtual Fornecedor Fornecedor { get; private set; }

        public Endereco(string rua, int numero, string cidade, EUfEstado estado, int idFornecedor)
        {
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            IdFornecedor = idFornecedor;
        }

        public Endereco(int id, string rua, int numero, string cidade, EUfEstado estado, int idFornecedor)
        {
            Id = id;
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            IdFornecedor = idFornecedor;
        }

        public Endereco(int id, string rua, int numero, string cidade, EUfEstado estado)
        {
            Id = id;
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
        }

        public Endereco()
        {

        }

    }
}
