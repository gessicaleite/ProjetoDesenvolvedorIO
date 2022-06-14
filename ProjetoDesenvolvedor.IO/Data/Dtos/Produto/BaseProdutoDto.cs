using ProjetoDesenvolvedor.IO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDesenvolvedor.IO.Data.Dtos.Produto
{
    public class BaseProdutoDto
    {
        public string Nome { get; private set; }

        public double Valor { get; private set; }

        public EAtivoInativo Situacao { get; private set; }

        public string Descricao { get; private set; }

        public string Imagem { get; private set; }
    }
}
