using RedeSocialUniversidade.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialUniversidade.Infra.Interfaces
{
    public interface IEventoRepository
    {
        Evento ObterPorId(int id);
        List<Evento> ObterTodos();
        void Adicionar(Evento evento);
        void Atualizar(Evento evento);
        void Remover(int id);
    }
}
