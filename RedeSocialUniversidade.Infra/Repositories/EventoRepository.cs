using Microsoft.Extensions.Logging;
using RedeSocialUniversidade.Domain;
using RedeSocialUniversidade.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialUniversidade.Infra.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly AppDbContext sqlContext;

        public EventoRepository()
        {
            sqlContext = new AppDbContext();
        }

        private List<Evento> eventos = new List<Evento>();

        public Evento ObterPorId(int id)
        {
            return eventos.FirstOrDefault(u => u.Id == id);
        }

        public List<Evento> ObterTodos()
        {
            return eventos;
        }

        public void Adicionar(Evento evento)
        {
            eventos.Add(evento);
        }

        public void Atualizar(Evento evento)
        {
            var eventoExistente = eventos.FirstOrDefault(u => u.Id == evento.Id);
            if (eventoExistente != null)
            {
                eventos.Remove(eventoExistente);
                eventos.Add(evento);
            }
        }

        public void Remover(int id)
        {
            var usuario = eventos.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                eventos.Remove(usuario);
            }
        }
        
    }
}
