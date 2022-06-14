using ProjetoDesenvolvedor.IO.Data.Dtos.Endereco;
using ProjetoDesenvolvedor.IO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDesenvolvedor.IO.Data.Dtos.Fornecedor
{
    public class BaseFornecedorDto
    {
        public string Nome { get; private set; }

        public string Documento { get; private set; }

        public EAtivoInativo Situacao { get; private set; }

        public ETipoCliente TipoPessoa { get; private set; }
    }
}
