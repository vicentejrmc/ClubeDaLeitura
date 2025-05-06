using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloReservas
{
    public class TelaReserva : TelaBase<Reserva>, ITelaCrud
    {
        protected IRepositorioReserva repositorioReserva;
        protected IRepositorioAmigo repositorioAmigo;
        protected IRepositorioRevista repositorioRevista;
        private IRepositorioCaixa repositorioCaixa;

        public TelaReserva(IRepositorioReserva repositorioReserva, IRepositorioAmigo repositorioAmigo, IRepositorioRevista repositorioRevista)
            : base("Reserva", repositorioReserva)
        {
            this.repositorioReserva = repositorioReserva;
            this.repositorioAmigo = repositorioAmigo;
            this.repositorioRevista = repositorioRevista;
        }

        public override char ApresentarMenu()
        {
            Console.Clear();
            ExibirCabecalho();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"[1] Cadastrar Reserva");
            Console.WriteLine($"[2] Visualizar Reserva");
            Console.WriteLine($"[3] Editar Reserva");
            Console.WriteLine($"[4] Excluir Reserva");
            Console.WriteLine($"[5] Converter Reserva");

            Console.WriteLine($"[S] Sair...");
            Console.WriteLine("------------------------------------------");

            Console.Write("Escolha uma opção válida: ");
            string opcaoStr = Console.ReadLine()!.ToUpper() ?? string.Empty;

            char opcao = '0';
            if (opcaoStr.Length > 0)
                opcao = Convert.ToChar(opcaoStr);
            else
            {
                Notificar.ExibirMensagem("Opção inválida! Tente novamente.", ConsoleColor.Red);
                return '0';
            }

            if (opcao == '5')
                ConverterReserva();
   

            return opcao;
        }

        private void ConverterReserva()
        {
            ExibirCabecalho();
            VisualizarRegistros();

            Console.WriteLine("Digite o Id da Reserva");
        }

        public override void InserirRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine($"Cadastrando {nomeEntidade}.");
            Console.WriteLine("------------------------------------------\n");

            if (repositorioRevista.SelecionarTodos().Count == 0)
            {
                Notificar.ExibirMensagem("Você precisa Cadastrar Revistas antes de criar uma nova Reserva!", ConsoleColor.Red);
                return;
            }

            Reserva novaReserva = (Reserva)ObterDados();

            string ehValido = novaReserva.Validar();

            if (ehValido.Length > 0)
            {
                Notificar.ExibirMensagem(ehValido, ConsoleColor.Red);  return;
            }

            Notificar.ExibirCores("Dados da Reserva:", ConsoleColor.DarkRed);
            Console.Write($"Amigo: {novaReserva.AmigoRes.Nome}  Revista: {novaReserva.Revista.Titulo} Data: {novaReserva.DataReserva.ToShortDateString}");

            Console.Write("Confirmar Reserva? S/N: ");
            string confirmacao = Console.ReadLine()!.ToUpper();
            if (confirmacao != "S")
            {
                Notificar.ExibirMensagem("Reserva Cancelada!", ConsoleColor.Red); return;
            }

            novaReserva.Revista.Reservar(novaReserva.Revista);
            novaReserva.AmigoRes.BloquearAmigo(novaReserva.AmigoRes);

            repositorioReserva.CadastrarRegistro(novaReserva);

            Notificar.ExibirMensagem($"Reserva de  realizada com sucesso!", ConsoleColor.Green);
        }

        public override Reserva ObterDados()
        {
            TelaAmigo telaAmigo = new TelaAmigo(repositorioAmigo);
            telaAmigo.VisualizarRegistros();
            Console.WriteLine("Selecione o Id do Amigo que irá efetuar a reserva: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine()! ?? string.Empty);
            Amigo amigo = (Amigo)repositorioAmigo.SelecionarRegistroPorId(idAmigo);

            TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
            telaRevista.VisualizarRegistros();
            Console.WriteLine("Selecione o Id da Revista que irá ser reservada: ");
            int idRevista = Convert.ToInt32(Console.ReadLine()! ?? string.Empty);
            Revista revista = (Revista)repositorioRevista.SelecionarRegistroPorId(idRevista);

            DateTime dataReserva = DateTime.Now;
            Reserva novaReserva = new Reserva(amigo, revista, dataReserva);

            return novaReserva;
        }

        public override void VisualizarRegistros()
        {
            ExibirCabecalho();

            Console.WriteLine("{0, -8} | {1, -20} | {2, -20} | {3, 15}", 
                "Id Reserva", "Revista", "Amigo", "DataReserva");

            List<Reserva> reservas = repositorioReserva.SelecionarTodos();

            if (reservas.Count == 0)
            {
                Notificar.ExibirMensagem("Nenhuma reserva cadastrada!", ConsoleColor.Red); return;
            }

            foreach (Reserva res in reservas)
            {
                Console.WriteLine("{0, -8} | {1, -20} | {2, -20} | {3, 15}",
                    res.Id, res.Revista.Titulo, res.AmigoRes.Nome, res.DataReserva.ToShortDateString());
            }

            Notificar.ExibirMensagem("Pressione qualquer tecla para continuar...", ConsoleColor.Yellow);
        }
    }
}
