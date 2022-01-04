using System;
using System.Collections.Generic;
using System.Linq;
using APIAgenda.Data;
using APIAgenda.Models;
using APIProdutos.Data;
using APIProdutos.Models;

namespace APIAgenda.Business
{
    public class EventoService
    {
        private ApplicationDbContext _context;

        public EventoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Evento Obter(string nome)
        {
            if (!String.IsNullOrWhiteSpace(nome))
            {
                return _context.Evento.Where(
                    p => p.nome == nome).FirstOrDefault();
            }
            else
                return null;
        }

        public IEnumerable<Evento> ListarTodos()
        {
            return _context.Evento
                .OrderBy(p => p.Nome).ToList();
        }

        public Resultado Incluir(Evento dadosProduto)
        {
            Resultado resultado = DadosValidos(dadosProduto);
            resultado.Acao = "Inclusão de novo evento";

            if (resultado.Inconsistencias.Count == 0 &&
                _context.Evento.Where(
                p => p.CodigoBarras == dadosProduto.CodigoBarras).Count() > 0)
            {
                resultado.Inconsistencias.Add(
                    "Esse evento já foi cadastrado");
            }

            if (resultado.Inconsistencias.Count == 0)
            {
                _context.Evento.Add(dadosProduto);
                _context.SaveChanges();
            }

            return resultado;
        }

        public Resultado Atualizar(Evento dadosEvento)
        {
            Resultado resultado = DadosValidos(dadosEvento);
            resultado.Acao = "Atualização de Evento";

            if (resultado.Inconsistencias.Count == 0)
            {
                Evento evento = _context.Evento.Where(
                    p => p.nome == dadosProduto.nome).FirstOrDefault();

                if (nome == null)
                {
                    resultado.Inconsistencias.Add(
                        "Evento não encontrado");
                }
                else
                {
                    evento.Nome = dadosEvento.Nome;
                    evento.Descricao = dadosEvento.Descricao;
                    evento.Descricao = dadosEvento.Descricao;
                    _context.SaveChanges();
                }
            }

            return resultado;
        }

        public Resultado Excluir(string nome)
        {
            Resultado resultado = new Resultado();
            resultado.Acao = "Exclusão de Evento";

            Evento evento = Obter(nome);
            if (evento == null)
            {
                resultado.Inconsistencias.Add(
                    "Evento não encontrado");
            }
            else
            {
                _context.Evento.Remove(evento);
                _context.SaveChanges();
            }
                
            return resultado;
        }

        private Resultado DadosValidos(Evento evento)
        {
            var resultado = new Resultado();
            if (evento == null)
            {
                resultado.Inconsistencias.Add(
                    "Preencha os Dados do Evento");
            }
            else
            {
                //Nome, descrição, data, local, participantes;
                if (String.IsNullOrWhiteSpace(evento.Nome))
                {
                    resultado.Inconsistencias.Add(
                        "Preencha o Nome do evento");
                }
                if (String.IsNullOrWhiteSpace(evento.descricao))
                {
                    resultado.Inconsistencias.Add(
                        "Preencha a descricao do evento");
                }
                if (String.IsNullOrWhiteSpace(evento.local))
                {
                    resultado.Inconsistencias.Add(
                        "Preencha o local do evento");
                }
                if (String.IsNullOrWhiteSpace(evento.participantes))
                {
                    resultado.Inconsistencias.Add(
                        "Preencha o(s) participantes reponsáveis pelo evento");
                }
            }

            return resultado;
        }
    }
} b