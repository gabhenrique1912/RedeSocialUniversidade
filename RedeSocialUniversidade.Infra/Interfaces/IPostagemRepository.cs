using RedeSocialUniversidade.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialUniversidade.Infra.Interfaces
{
    public interface IPostagemRepository
    {
        Postagem ObterPorId(int id);
        List<Postagem> ObterTodos();
        void Adicionar(Postagem postagem);
        void Atualizar(Postagem postagem);
        void Remover(int id);
    }
}
