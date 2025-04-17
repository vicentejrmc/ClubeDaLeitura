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

}
