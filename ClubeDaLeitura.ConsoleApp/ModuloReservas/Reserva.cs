using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
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
        public string Revista { get; set; }
        public DateTime DataReserva { get; set; }

        public Reserva(Amigo amigo, string revista, DateTime dataReserva)
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

            if (string.IsNullOrWhiteSpace(Revista))
                erros += "Erro! O nome da revista não pode ser vazio.\n";

            if (DataReserva == null)
                erros += "Erro! A data da reserva não pode ser nula.\n";

            if (DataReserva < DateTime.Now)
                erros += "Erro! A data da reserva não pode ser no passado.\n";

            Regex regex = new Regex(@"^\d{2}/\d{2}/\d{4}$");
            if (!regex.IsMatch(DataReserva.ToString("dd/MM/yyyy")))
                erros += "Erro! A data da reserva deve estar no formato dd/MM/yyyy.\n";

            if(AmigoReserv.Multa ==  )

            return erros;
        }
    }
}
