using ProjetoDesenvolvedor.IO.Enum;

namespace ProjetoDesenvolvedor.IO.Data.Dtos.Produto
{
    public class UpdateProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public double Valor { get; set; }

        public EAtivoInativo Situacao { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public int IdFornecedor { get; set; }
    }
}
