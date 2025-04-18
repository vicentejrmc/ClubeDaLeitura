using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;

namespace ClubeDaLeitura.ConsoleApp.Util;

public class TelaPrincipal
{
    private char mainOption;
    private RepositorioAmigo repositorioAmigo; // instancia de repositorio.

    public TelaPrincipal()  // Construtor de TelaPrincipal
    {
        this.repositorioAmigo = repositorioAmigo;
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("------------------------------------------");
        Console.WriteLine("|        Clube da Leitura 2025           |");
        Console.WriteLine("------------------------------------------\n");

        Console.WriteLine("    ------------------------------");
        Console.WriteLine("    | [1] Gestão de Amigos       |");
        Console.WriteLine("    | [2] Gestão de Caixas.      |");
        Console.WriteLine("    | [3] Gestão de Revistas.    |");
        Console.WriteLine("    | [4] Gestão de Emprestimos. |");
        Console.WriteLine("    | [S] Sair...                |");
        Console.WriteLine("    ------------------------------");
        Console.Write("    | Escolha uma opção válida: ");
        mainOption = Console.ReadLine().ToUpper()![0];
    }

    public TelaBase ObterTela()  // Método depentende de ApresentarMenuPrincipal()
    {
        if (mainOption == '1')
            return new TelaAmigo(repositorioAmigo);

        //else if (mainOption == '2')

        //    return new TelaCaixa();

        //else if (mainOption == '3')

        //    return new TelaRevista();
        //else if (mainOption == '4')

        //    return new TelaEmprestimo();

        //else
        return null;
    }

}
