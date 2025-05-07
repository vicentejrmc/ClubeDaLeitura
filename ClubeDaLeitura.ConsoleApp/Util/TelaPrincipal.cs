using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloReservas;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Threading.Channels;

namespace ClubeDaLeitura.ConsoleApp.Util;

public class TelaPrincipal
{
    private char mainOption;
    public IRepositorioAmigo repositorioAmigo;
    public IRepositorioCaixa repositorioCaixa;
    public IRepositorioRevista repositorioRevista;
    public IRepositorioEmprestimo repositorioEmprestimo;
    public IRepositorioReserva repositorioReserva;
    public TelaEmprestimo telaEmprestimo;

    public TelaPrincipal()  // Construtor de TelaPrincipal
    {
        this.repositorioAmigo = new ReposAmigoArquivo();
        this.repositorioCaixa = new ReposCaixaArquivo();
        this.repositorioRevista = new ReposRevistaArquivo();
        this.repositorioEmprestimo = new ReposEmprestimoArquivo();
        this.telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioRevista, repositorioAmigo, repositorioCaixa);
        this.repositorioReserva = new ReposReservarArquivo();
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Clube da Leitura 2025");
        Console.WriteLine("------------------------------------------\n");

        Console.WriteLine("------------------------------------------");
        Console.WriteLine("[1] Gestão de Amigos       ");
        Console.WriteLine("[2] Gestão de Caixas.      ");
        Console.WriteLine("[3] Gestão de Revistas.    ");
        Console.WriteLine("[4] Gestão de Emprestimos. ");
        Console.WriteLine("[5] Gestão de Reservas. ");
        Console.WriteLine("[S] Sair...                ");
        Console.WriteLine("------------------------------------------");
        Console.Write("Escolha uma opção válida: ");

        string opcao = Console.ReadLine()!.ToUpper() ?? string.Empty;
        if (opcao.Length > 0)
            mainOption = Convert.ToChar(opcao[0]);
        else
        {
            Notificar.ExibirMensagem("Opção inválida! Tente novamente.", ConsoleColor.Red);

            ApresentarMenuPrincipal();
        }
    }

    public ITelaCrud ObterTela()
    {
        if (mainOption == 'S')
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine("Saindo do Sistema....");
            Console.WriteLine("---------------------");
            Thread.Sleep(2000); 
            Environment.Exit(0);
        }


        if (mainOption == '1')
            return new TelaAmigo(repositorioAmigo);

        else if (mainOption == '2')
            return new TelaCaixa(repositorioCaixa);

        else if (mainOption == '3')
            return new TelaRevista(repositorioRevista, repositorioCaixa);

        else if (mainOption == '4')
            return new TelaEmprestimo(repositorioEmprestimo, repositorioRevista, repositorioAmigo, repositorioCaixa);

        else if (mainOption == '5')
            return new TelaReserva(repositorioReserva, repositorioAmigo, repositorioRevista);

        else
        {
            Notificar.ExibirMensagem("Opção inválida! Tente novamente.", ConsoleColor.Red);
            ApresentarMenuPrincipal();
        }
        return null;
    }

}
