using System.Collections.Generic;
using APIAgenda.Business;
using APIAgenda.Models;
using Microsoft.AspNetCore.Mvc;
using APIProdutos.Business;
using APIProdutos.Models;
using Microsoft.AspNetCore.Authorization;

namespace APIAgenda.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class EventosController : Controller
    {
        private EventoService _service;

        public EventosController(EventoService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _service.ListarTodos();
        }

        [HttpGet("{nome}")]
        public IActionResult Get(string nome)
        {
            var nome = _service.Obter(nome);
            if (nome != null)
                return new ObjectResult(nome);
            else
                return NotFound();
        }

        [HttpPost]
        public Resultado Post([FromBody]Evento evento)
        {
            return _service.Incluir(evento);
        }

        [HttpPut]
        public Resultado Put([FromBody]Evento evento)
        {
            return _service.Atualizar(evento);
        }

        [HttpDelete("{nome}")]
        public Resultado Delete(string nome)
        {
            return _service.Excluir(nome);
        }
    }
}