using Microsoft.AspNetCore.Mvc;
using ProjetoDesenvolvedor.IO.Interfaces;

namespace ProjetoDesenvolvedor.IO.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly INotificador _notificador;

        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected IActionResult VerificarNotificacoes()
        {
            if (_notificador.TemNotificacao())
            {
                return BadRequest(_notificador.ObterNotificacoes());
            }
            return NotFound();
        }
    }
}
