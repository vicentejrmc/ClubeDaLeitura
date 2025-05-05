using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloReservas
{
    public class Reserva : EntidadeBase<Reserva>
    {
        public Amigo AmigoReserv { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataReserva { get; set; }

        public Reserva(Amigo amigo, Revista revista, DateTime dataReserva)
        {
            AmigoReserv = amigo;
            Revista = revista;
            DataReserva = dataReserva;
        }

        public override void AtualizarRegistro(Reserva resgitroEditado)
        {
            AmigoReserv = resgitroEditado.AmigoReserv;
            Revista = resgitroEditado.Revista;
            DataReserva = resgitroEditado.DataReserva;
        }

        public override string Validar()
        {
            string erros = "";

            if (AmigoReserv == null)
                erros += "Erro! O amigo não pode ser nulo.\n";

            if(!AmigoReserv.status.Equals("Ativo"))
                erros += "Erro! O amigo não pode efetuara uma reserva. Possiveis Motivos: Reserva em Aberto, Multa pendente ou Emprestimo. / \n";

            if (Revista == null)
                erros += "Erro! A revista não pode ser nula.\n";

            if(!Revista.StatusEmprestimo.Equals("Disponível"))
                erros += "Erro! A revista não pode ser reservada. A mesma se já está Emprestada ou Reservada.\n";

            Regex regex = new Regex(@"^\d{2}/\d{2}/\d{4}$");
            if (!regex.IsMatch(DataReserva.ToString("dd/MM/yyyy")))
                erros += "Erro! A data da reserva deve estar no formato dd/MM/yyyy.\n";
            
            // validação de amigo com Emprestimo ou multa em atrazado deverá ser feito na TelaReserva(Amigo não pode reservar)

            return erros;
        }
    }
}
