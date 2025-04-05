using Microsoft.AspNetCore.Mvc;
using RedeSocialUniversidade.Domain;
using RedeSocialUniversidade.Infra.Repositories;
using System.Collections.Generic;

namespace RedeSocialUniversidade.API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public ActionResult<List<Usuario>> ObterTodos()
        {
            var usuarios = _usuarioRepository.ObterTodos();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> ObterPorId(int id)
        {
            var usuario = _usuarioRepository.ObterPorId(id);
            if (usuario == null)
                return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult Adicionar(Usuario usuario)
        {
            _usuarioRepository.Adicionar(usuario);
            return CreatedAtAction(nameof(ObterPorId), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, Usuario usuario)
        {
            if (id != usuario.Id)
                return BadRequest();

            _usuarioRepository.Atualizar(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remover(int id)
        {
            _usuarioRepository.Remover(id);
            return NoContent();
        }

        [HttpGet("{id}/seguidores")]
        public ActionResult<List<Usuario>> ObterSeguidores(int id)
        {
            var seguidores = _usuarioRepository.ObterSeguidores(id);
            return Ok(seguidores);
        }
    }
}
