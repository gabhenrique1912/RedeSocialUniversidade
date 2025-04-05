using RedeSocialUniversidade.Domain;
using RedeSocialUniversidade.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialUniversidade.Infra.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        private readonly AppDbContext sqlContext;

        public PostagemRepository()
        {
            sqlContext = new AppDbContext();
        }

        private List<Postagem> postagens = new List<Postagem>();

        public Postagem ObterPorId(int id)
        {
            return postagens.FirstOrDefault(u => u.Id == id);
        }

        public List<Postagem> ObterTodos()
        {
            return postagens;
        }

        public void Adicionar(Postagem postagem)
        {
            postagens.Add(postagem);
        }

        public void Atualizar(Postagem postagem)
        {
            var postagemExistente = postagens.FirstOrDefault(u => u.Id == postagem.Id);
            if (postagemExistente != null)
            {
                postagens.Remove(postagemExistente);
                postagens.Add(postagem);
            }
        }

        public void Remover(int id)
        {
            var postagem = postagens.FirstOrDefault(u => u.Id == id);
            if (postagem != null)
            {
                postagens.Remove(postagem);
            }
        }

    }
}
