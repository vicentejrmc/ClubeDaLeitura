﻿using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class Revista : EntidadeBase<Revista>
    {
        private Caixa caixaSelecionada;

        public string Titulo { get; set; }
        public int Edicao { get; set; }
        public int AnoPublicacao { get; set; }
        public string StatusEmprestimo { get; set; }
        public Caixa Caixa { get; set; }

        public Revista()
        {
            Caixa = new Caixa();
        }

        public Revista(string titulo, int edicao, int anoPublicacao, string statusEmprestimo, Caixa caixa)
        {
            Titulo = titulo;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
            StatusEmprestimo = statusEmprestimo;
            Caixa = caixa;
        }

        public override void AtualizarRegistro(Revista revistaEditada)
        {
            Titulo = revistaEditada.Titulo;
            Edicao = revistaEditada.Edicao;
            AnoPublicacao = revistaEditada.AnoPublicacao;
            StatusEmprestimo = revistaEditada.StatusEmprestimo;
            caixaSelecionada = revistaEditada.caixaSelecionada;
        }

        public override string Validar()
        {
            string erros = "";

            if (String.IsNullOrWhiteSpace(Titulo))
                erros += "Erro! O campo 'Título' não pode ficar em branco.\n";

            if(Titulo.Length < 2 || Titulo.Length > 100)
                erros += "Erro! O campo 'Título' deve ter entre 2 e 100 caracteres.\n";
            
            if(Edicao == null)
                erros += "Erro! O campo 'Edição' não pode ficar em branco.\n";

            if (Edicao < 1)
                erros += "Erro! O campo 'Edição' deve ser maior que 0.\n";

            if (AnoPublicacao == null)
                erros += "Erro! O campo 'Ano de Publicação' não pode ficar em branco.\n";

            if (AnoPublicacao > DateTime.Now.Year)
                erros += "Erro! O campo 'Ano de Publicação' deve ser maior que 1900 e menor ou igual ao ano atual.\n";

            if (StatusEmprestimo == "Emprestada")
                erros += "Erro! Não é possível excluir uma revista que está emprestada.\n";

            return erros;
        }

        public void Emprestar(Revista revista) // Verificar Método
        {
            if (revista.StatusEmprestimo == "Emprestada")
            {
                return;
            }
            else
            {
                revista.StatusEmprestimo = "Emprestada";
            }
        }

        public void Devolver(Revista revista) // Verificar Método
        {
            if (revista.StatusEmprestimo == "Disponível")
            {
                return;
            }
            else
            {
                revista.StatusEmprestimo = "Disponível";
            }
        }

        public void Reservar(Revista revista) // Verificar Método
        {
            if (revista.StatusEmprestimo == "Reservada")
            {
                return;
            }
            else
            {
                revista.StatusEmprestimo = "Reservada";
            }
        }
    }
}
