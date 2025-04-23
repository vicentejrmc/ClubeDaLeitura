using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.Util;

namespace ClubeDaLeitura.ConsoleApp;

class Program
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

                case '2': telaSelecionada.VisualizarRegistros(); break;

                case '3': telaSelecionada.EditarRegistro(); break;

                case '4': telaSelecionada.ExcluirRegistro(); break;
            }
        }
    }
}
