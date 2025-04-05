using Microsoft.AspNetCore.Mvc;
using RedeSocialUniversidade.Domain;
using RedeSocialUniversidade.Infra.Repositories;
using System.Collections.Generic;

namespace RedeSocialUniversidade.API.Controllers
{
    [ApiController]
    [Route("api/eventos")]
    public class EventoController : ControllerBase
    {
        private readonly EventoRepository _eventoRepository;

        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }

        [HttpGet]
        public ActionResult<List<Evento>> ObterTodos()
        {
            var eventos = _eventoRepository.ObterTodos();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public ActionResult<Evento> ObterPorId(int id)
        {
            var evento = _eventoRepository.ObterPorId(id);
            if (evento == null)
                return NotFound();
            return Ok(evento);
        }

        [HttpPost]
        public ActionResult Adicionar(Evento evento)
        {
            _eventoRepository.Adicionar(evento);
            return CreatedAtAction(nameof(ObterPorId), new { id = evento.Id }, evento);
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, Evento evento)
        {
            if (id != evento.Id)
                return BadRequest();

            _eventoRepository.Atualizar(evento);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            _eventoRepository.Remover(id);
            return NoContent();
        }
    }
}