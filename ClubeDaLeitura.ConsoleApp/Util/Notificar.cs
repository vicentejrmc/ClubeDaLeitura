using System.Runtime.ConstrainedExecution;

namespace ClubeDaLeitura.ConsoleApp.Util;

internal class Notificar
{
    public static void ExibirMensagem(string mensagem, ConsoleColor cor)
    {
        Console.ForegroundColor = cor;
        Console.WriteLine();
        Console.WriteLine(mensagem);
        Console.ResetColor();
        Console.ReadLine();
    }

    public static void ExibirCores(string descricao, ConsoleColor cor)
    {
        Console.ForegroundColor = cor;
        Console.WriteLine(descricao);
        Console.ResetColor();
    }

}
