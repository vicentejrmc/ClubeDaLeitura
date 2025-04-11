namespace ClubeDaLeitura.ConsoleApp.Compatilhado;

public class TelaPrincipal
{
    public string MenuPrincipal()
    {
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("|              Clube da Leitura                     |");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.WriteLine("Seja bem-vindo ao Clube da Leitura!");
        Console.WriteLine("-----------------------------------------------------");

        Console.WriteLine("1 - Gerenciar Amigos.");
        Console.WriteLine("2 - Gerenciar Caixas.");
        Console.WriteLine("3 - Gerenciar Revistas.");
        Console.WriteLine("4 - Gerenciar Empréstimos.");
        Console.WriteLine("S - Sair do Sistema.");
        Console.WriteLine("-----------------------------------------------------\n");

        Console.Write("Digite uma opção válida: ");
        string opcao = Console.ReadLine().ToUpper(); ;

        return opcao;
    }
}