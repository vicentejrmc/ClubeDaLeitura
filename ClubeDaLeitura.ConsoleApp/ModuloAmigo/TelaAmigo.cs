using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaAmigo : TelaBase
    {
        public RepositorioAmigo repositorioAmigo;

        public TelaAmigo(RepositorioAmigo repositorioAmigo) 
            : base("Amigo", repositorioAmigo)
        {
            this.repositorioAmigo = repositorioAmigo;
        }

        public override Amigo ObterDados()
        {
            Console.Write("Insira o nome: ");
            string nome = Console.ReadLine()!;

            Console.Write("Insira o nome do responsável: ");
            string responsavel = Console.ReadLine()!;

            Console.Write("Insira o telefone: ");
            string telefone = Console.ReadLine()!;

            Amigo novoAmigo = new Amigo(nome, responsavel, telefone);

            return novoAmigo;
        }

        public override void InserirRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Cadastrando Amigo.");
            Console.WriteLine("------------------------------------------\n");

            Amigo novoRegistro = (Amigo)ObterDados();

            string ehValido = novoRegistro.Validar();

            if (ehValido.Length > 0)
            {
                Notificar.ExibirMensagem(ehValido, ConsoleColor.Red);
                InserirRegistro();
                return;
            }

            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();

            repositorioAmigo.CadastrarRegistro(novoRegistro);

            Notificar.ExibirMensagem($"Cadastro de {nomeEntidade} realizado com sucesso!", ConsoleColor.Green);
        }


        public override void VisualizarRegistros(bool e)
        {
            throw new NotImplementedException();
        }
    }
}
