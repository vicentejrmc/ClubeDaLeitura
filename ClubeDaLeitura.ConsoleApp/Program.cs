using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
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

            ItelaCrud telaSelecionada = telaPrincipal.ObterTela();

            char opcaoEscolhida = telaSelecionada.ApresentarMenu();

            switch (opcaoEscolhida)
            {
                case '1': telaSelecionada.InserirRegistro(); break;

                case '2': telaSelecionada.VisualizarRegistros(); break;

                case '3': telaSelecionada.EditarRegistro(); break;

                case '4': telaSelecionada.ExcluirRegistro(); break;

            }
        }
    }
}
