using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.Util;

namespace ClubeDaLeitura.ConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        TelaPrincipal telaPrincipal = new TelaPrincipal();

        while (true)
        {
            telaPrincipal.ApresentarMenuPrincipal();

            TelaBase telaSelecionada = telaPrincipal.ObterTela();

            char opscaoEscolhida = telaSelecionada.ApresentarMenu();

            switch (opscaoEscolhida)
            {
                case '1': telaSelecionada.InserirRegistro(); break;

                case '2': telaSelecionada.VisualizarRegistro(); break;

                case '3': telaSelecionada.EditarRegistro(); break;

                case '4': telaSelecionada.ExcluirRegistro(); break;
            }
        }
    }
}
