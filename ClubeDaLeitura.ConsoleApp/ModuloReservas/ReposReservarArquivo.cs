using ClubeDaLeitura.ConsoleApp.Compatilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloReservas
{
    public class ReposReservarArquivo : ReposBaseArquivo<Reserva>, IRepositorioReserva
    {
        public ReposReservarArquivo(ContextoDados contexto) : base(contexto)
        {
        }
        protected override List<Reserva> ObterRegistros()
        {
            return contexto.Reservas;
        }
    }
}
