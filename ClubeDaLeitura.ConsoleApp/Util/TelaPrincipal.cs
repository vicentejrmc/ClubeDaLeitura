using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Threading.Channels;

namespace ClubeDaLeitura.ConsoleApp.Util;

public class TelaPrincipal
{
    private char mainOption;
    public ReposAmigoMemoria repositorioAmigo;
    public ReposCaixaMemoria repositorioCaixa;
    public ReposRevistaMemoria RepositorioRevista;
    public ReposEmprestimoMemoria repositorioEmprestimo;
    public TelaEmprestimo telaEmprestimo;

    public TelaPrincipal()  // Construtor de TelaPrincipal
    {
        this.repositorioAmigo = new ReposAmigoMemoria();
        this.repositorioCaixa = new ReposCaixaMemoria();
        this.RepositorioRevista = new ReposRevistaMemoria();
        this.repositorioEmprestimo = new ReposEmprestimoMemoria();
        this.telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, RepositorioRevista, repositorioAmigo, repositorioCaixa);
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
        Console.WriteLine("[S] Sair...                ");
        Console.WriteLine("------------------------------------------");
        Console.Write("Escolha uma opção válida: ");
        mainOption = Convert.ToChar(Console.ReadLine().ToUpper());
    }

    public ItelaCrud ObterTela() 
    {
        if (mainOption == 'S')
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine("Saindo do Sistema....");
            Console.WriteLine("---------------------");
            Thread.Sleep(1500); ;
            Environment.Exit(0);
        }


        if (mainOption == '1')
            return new TelaAmigo(repositorioAmigo);

        else if (mainOption == '2')
            return new TelaCaixa(repositorioCaixa);

        else if (mainOption == '3')
            return new TelaRevista(RepositorioRevista, repositorioCaixa);

        else if (mainOption == '4')
            return new TelaEmprestimo(repositorioEmprestimo, RepositorioRevista, repositorioAmigo, repositorioCaixa);

        else
            Notificar.ExibirMensagem("Opção inválida! Tente novamente.", ConsoleColor.Red);

        ApresentarMenuPrincipal();

        return null;
    }

}
