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
        public Reserva() { }

        public Amigo AmigoRes { get; set; }
        public Revista Revista { get; set; }
        public DateTime DataReserva { get; set; }

        public Reserva(Amigo amigoRes, Revista revista, DateTime dataReserva)
        {
            AmigoRes = amigoRes;
            Revista = revista;
            DataReserva = dataReserva;
        }

        public override void AtualizarRegistro(Reserva resgitroEditado)
        {
            AmigoRes = resgitroEditado.AmigoRes;
            Revista = resgitroEditado.Revista;
            DataReserva = resgitroEditado.DataReserva;
        }

        public override string Validar()
        {
            string erros = "";

            if (AmigoRes == null)
                erros += "Erro! O amigo não pode ser nulo.\n";

            if(!AmigoRes.status.Equals("Ativo"))
                erros += "Erro! O amigo não pode efetuara uma reserva. Possiveis Motivos: Reserva em Aberto, Multa pendente ou Emprestimo. / \n";

            if (Revista == null)
                erros += "Erro! A revista não pode ser nula.\n";

            //if(!Revista.StatusEmprestimo.Equals("Disponivel"))
               // erros += "Erro! A revista não pode ser reservada. A mesma se já está Emprestada ou Reservada.\n";

            Regex regex = new Regex(@"^\d{2}/\d{2}/\d{4}$");
            if (!regex.IsMatch(DataReserva.ToString("dd/MM/yyyy")))
                erros += "Erro! A data da reserva deve estar no formato dd/MM/yyyy.\n";
            
            // validação de amigo com Emprestimo ou multa em atrazado deverá ser feito na TelaReserva(Amigo não pode reservar)

            return erros;
        }
    }
}
