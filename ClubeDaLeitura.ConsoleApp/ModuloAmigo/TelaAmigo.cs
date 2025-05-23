﻿using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.Util;
using System;
using System.Collections;


namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class TelaAmigo : TelaBase<Amigo>, ITelaCrud
    {
        public IRepositorioAmigo repositorioAmigo;

        public TelaAmigo(IRepositorioAmigo repositorioAmigo) : base ("Amigo", repositorioAmigo)
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

            foreach (var amigo in repositorioAmigo.SelecionarTodos())
            {
                if (amigo.Nome.Equals(novoRegistro.Nome)) 
                {
                    Notificar.ExibirMensagem("Erro! Já existe um amigo cadastrado com o mesmo Nome.", ConsoleColor.Red);
                    return;
                }
                if (amigo.Telefone.Equals(novoRegistro.Telefone))
                {
                    Notificar.ExibirMensagem("Erro! Já existe um amigo cadastrado com o mesmo Telefone.", ConsoleColor.Red);
                    return;
                }
            }

            repositorioAmigo.CadastrarRegistro(novoRegistro);

            Notificar.ExibirMensagem($"Cadastro de {nomeEntidade} realizado com sucesso!", ConsoleColor.Green);
        }

        public override void VisualizarRegistros()
        {
            ExibirCabecalho();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Visualizando Amigos.");
            Console.WriteLine("------------------------------------------\n");

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -15}", "ID" , "Nome", "Responsável", "Telefone");

            if (repositorioAmigo.SelecionarTodos().Count == 0)
            {
                Notificar.ExibirMensagem("Nenhum amigo cadastrado!", ConsoleColor.Red);
                return;
            }

            List<Amigo> registros = repositorioAmigo.SelecionarTodos();

            foreach (var amigo in registros)
            {
                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -15}",
                    amigo.Id, amigo.Nome, amigo.Responsavel, amigo.Telefone);
            }

            Console.WriteLine();
            Notificar.ExibirMensagem("Pressione entera para continuar", ConsoleColor.Yellow);
           
        }

        public override void EditarRegistro()
        {
            ExibirCabecalho();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Editando Amigo.");
            Console.WriteLine("------------------------------------------\n");

            VisualizarRegistros();

            Console.Write("Digite o ID do amigo que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine()!);

            Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarRegistroPorId(id);

            Amigo amigoEditado = (Amigo)ObterDados();

            string ehValido = amigoEditado.Validar();

            if (ehValido.Length > 0)
            {
                Notificar.ExibirMensagem(ehValido, ConsoleColor.Red);

                return;
            }

            bool conseguiuEditar = repositorioAmigo.EditarRegistro(id, amigoEditado);

            if(!conseguiuEditar)
            {
                Notificar.ExibirMensagem($"Erro! Não foi possível editar o amigo com ID {id}.", ConsoleColor.Red);

                return;
            }

            Notificar.ExibirMensagem("Amigo Editado com Sucesso!", ConsoleColor.Green);
        }

        public override void ExcluirRegistro()  // falta implementar Validação referente a emprestimos ativos
        {
            ExibirCabecalho();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Excluindo Amigo.");
            Console.WriteLine("------------------------------------------\n");

            if (repositorioAmigo.SelecionarTodos().Count == 0)
            {
                Notificar.ExibirMensagem("Nenhum amigo cadastrado!", ConsoleColor.Red);
                return;
            }

            VisualizarRegistros();

            Console.Write("Digite o ID do amigo que deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine()!);

            Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarRegistroPorId(id);

            // Validação (Amigo com emprestimo ativo não pode ser excluido)
            
            if (amigoSelecionado == null)
            {
                Notificar.ExibirMensagem($"Erro! Não foi possível encontrar o amigo com ID {id}.", ConsoleColor.Red);
                return;
            }
            
            bool conseguiuExcluir = repositorioAmigo.ExcluirRegistro(id);
            
            if (!conseguiuExcluir)
            {
                Notificar.ExibirMensagem($"Erro! Não foi possível excluir o amigo com ID {id}.", ConsoleColor.Red);
                return;
            }

            Notificar.ExibirMensagem($"Amigo {amigoSelecionado.Nome} excluído com sucesso!", ConsoleColor.Green);
        }
    }
}
