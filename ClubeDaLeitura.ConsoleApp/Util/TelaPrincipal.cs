using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Util;

public class TelaPrincipal
{
    private char mainOption;

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





}
