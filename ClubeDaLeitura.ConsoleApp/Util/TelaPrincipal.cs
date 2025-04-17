using ClubeDaLeitura.ConsoleApp.Compatilhado;

namespace ClubeDaLeitura.ConsoleApp.Util;

public class TelaPrincipal
{
    private char mainOption;     // criar instancias de objetos respositorios

    // private RepositorioAmigo repositorioAmigo;
    //------------------------------------------------------------------------
    public TelaPrincipal()
    {
        //Construtor da tela - instanciar repositorios depois de criados.
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
      throw new NotImplementedException();
        //implementar switch() case: break das opções do menu após implementação de Modulos filho.
    }



}
