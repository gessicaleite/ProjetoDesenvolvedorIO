using ProjetoDesenvolvedor.IO.Notificacoes;
using System.Collections.Generic;

namespace ProjetoDesenvolvedor.IO.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}
