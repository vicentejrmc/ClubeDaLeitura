using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compatilhado
{
    public abstract class TelaBase
    {
        protected string nomeEntidade;
        private RepositorioBase repositorio;

        protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
        {
            this.nomeEntidade = nomeEntidade;
            this.repositorio = repositorio;
        }

        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"         Gestao de {nomeEntidade}.       ");
            Console.WriteLine("------------------------------------------\n");
        }

        public virtual char ApresentarMenu()
        {
            Console.WriteLine($"[1] Cadastrar {nomeEntidade}.");
            Console.WriteLine($"[2] Visualizar {nomeEntidade}.");
            Console.WriteLine($"[3] Editar {nomeEntidade}.");
            Console.WriteLine($"[4] Excluir {nomeEntidade}.");
            Console.WriteLine($"[S] Sair do Menu Atual.");
            Console.WriteLine("------------------------------------------");

            Console.Write("Escolha uma opção válida: ");
            char opcao = Convert.ToChar(Console.ReadLine()!.ToUpper());

            return opcao;
        }

        internal void InserirRegistro()
        {
            ExibirCabecalho();
        }

        internal void VisualizarRegistro()
        {
            ExibirCabecalho();
        }

        internal void EditarRegistro()
        {
            ExibirCabecalho();
        }

        internal void ExcluirRegistro()
        {
            ExibirCabecalho();
        }
    }
}
