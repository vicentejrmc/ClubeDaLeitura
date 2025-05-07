using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
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
        protected IRepositorioEmprestimo repositorioEmprestimo;
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

            Console.WriteLine($"Convertendo Reserva.");
            Console.WriteLine("------------------------------------------\n");

            VisualizarRegistros();

            Console.Write("Digite o Id Da Reserva: ");
            int idReserva = Convert.ToInt32(Console.ReadLine()! ?? string.Empty);

            Reserva reservaSelecionada = (Reserva)repositorioReserva.SelecionarRegistroPorId(idReserva);

            if (reservaSelecionada == null)
            {
                Notificar.ExibirMensagem("Reserva não encontrada!", ConsoleColor.Red);
                return;
            }

            Console.Write("A Reserva dessa revista será removida, deseja confirmar? S/N: ");
            string escolha = Console.ReadLine()!.ToUpper() ?? string.Empty;

            if (escolha != "S")
            {
                Notificar.ExibirMensagem("Conersão de Reserva para emprestimo cancelada!", ConsoleColor.Yellow); return;
            }
            else
            {
                reservaSelecionada.Revista.Devolver(reservaSelecionada.Revista);

                Notificar.ExibirMensagem("Status de Reserva da Revista Cancelado", ConsoleColor.Green);
            }

            Console.WriteLine("Convertendo Reserva em Emprestimo...");
            Thread.Sleep(1000);

            DateTime dataAtual = DateTime.Now;

            int diasEmprestimo = reservaSelecionada.Revista.Caixa.DiasEmprestimo;

            DateTime dataDevol = DateTime.Now.AddDays(diasEmprestimo);

            Emprestimo emprestimo = new Emprestimo(reservaSelecionada.AmigoRes, reservaSelecionada.Revista, dataAtual, "Emprestada", dataDevol);

            repositorioEmprestimo.CadastrarRegistro(emprestimo);

            Notificar.ExibirMensagem("Reserva Convertida com sucesso!", ConsoleColor.Green);

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
            Console.Write("Selecione o Id do Amigo que irá efetuar a reserva: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine()! ?? string.Empty);
            Amigo amigo = (Amigo)repositorioAmigo.SelecionarRegistroPorId(idAmigo);

            TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
            telaRevista.VisualizarRegistros();
            Console.Write("Selecione o Id da Revista que irá ser reservada: ");
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
