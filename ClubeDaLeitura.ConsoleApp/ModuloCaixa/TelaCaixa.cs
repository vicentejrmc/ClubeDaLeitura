using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class TelaCaixa
    {
        private void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("|              Clube da Leitura                     |");
            Console.WriteLine("-----------------------------------------------------\n");
        }

        public void GerenciarCaixas()
        {
            ExibirCabecalho();

            Console.WriteLine("Gerenciar Caixas!");
            Console.WriteLine("-----------------------------------------------------\n");

            Console.WriteLine("1 - Cadastrar nova caixa.");
            Console.WriteLine("2 - Editar Caixa existente.");
            Console.WriteLine("3 - Excluir Caixa.");
            Console.WriteLine("4 - Visualizar Caixas.");
            Console.WriteLine("-----------------------------------------------------\n");

            string opcao = Console.ReadLine().ToUpper();

            switch (opcao)
            {
                case "1":
                    //CadastrarCaixa();
                    break;

                case "2":
                    //EditarCaixa();
                    break;

                case "3":
                    //ExcluirCaixa();
                    break;

                case "4":
                    //VisualizarCaixas();
                    break;

                default:
                    Notificador.ExibirMensagem("Opcção Invalida...!", ConsoleColor.Cyan);
                    break;

            }


        }


    }
}
