using Microsoft.AspNetCore.Mvc;
using RedeSocialUniversidade.Domain;
using RedeSocialUniversidade.Infra.Repositories;
using System.Collections.Generic;

namespace RedeSocialUniversidade.API.Controllers
{
    [ApiController]
    [Route("api/postagens")]
    public class PostagemController : ControllerBase
    {
        private readonly PostagemRepository _postagemRepository;

        public PostagemController()
        {
            _postagemRepository = new PostagemRepository();
        }

        [HttpGet]
        public ActionResult<List<Postagem>> ObterTodos()
        {
            var postagens = _postagemRepository.ObterTodos();
            return Ok(postagens);
        }

        [HttpGet("{id}")]
        public ActionResult<Postagem> ObterPorId(int id)
        {
            var postagem = _postagemRepository.ObterPorId(id);
            if (postagem == null)
                return NotFound();
            return Ok(postagem);
        }

        [HttpPost]
        public ActionResult Adicionar(Postagem postagem)
        {
            _postagemRepository.Adicionar(postagem);
            return CreatedAtAction(nameof(ObterPorId), new { id = postagem.Id }, postagem);
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, Postagem postagem)
        {
            if (id != postagem.Id)
                return BadRequest();

            _postagemRepository.Atualizar(postagem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            _postagemRepository.Remover(id);
            return NoContent();
        }
    }
}
