using ClubeDaLeitura.ConsoleApp.Compatilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class Revista : EntidadeBase<Revista>
    {
        public string Titulo { get; set; }
        public int Edicao { get; set; }
        public int AnoPublicacao { get; set; }
        public string StatusEmprestimo { get; set; }
        public string CaixaAtual { get; set; }

        public Revista(string titulo, int edicao, int anoPublicacao, string statusEmprestimo, string caixaAtual)
        {
            Titulo = titulo;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
            StatusEmprestimo = statusEmprestimo;
            CaixaAtual = caixaAtual;
        }

        public override void AtualizarRegistro(Revista resgitroEditado)
        {
            Revista revistarEditada = (Revista)resgitroEditado;

            Titulo = revistarEditada.Titulo;
            Edicao = revistarEditada.Edicao;
            AnoPublicacao = revistarEditada.AnoPublicacao;
            StatusEmprestimo = revistarEditada.StatusEmprestimo;
            CaixaAtual = revistarEditada.CaixaAtual;
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

            return erros;
        }

        public void Emprestar() // Verificar Método
        {
            if (StatusEmprestimo == "Emprestada")
            {
                return;
            }
            else
            {
                StatusEmprestimo = "Disponível";
            }
        }

        public void Devolver() // Verificar Método
        {
            if (StatusEmprestimo == "Disponível")
            {
                return;
            }
            else
            {
                StatusEmprestimo = "Emprestada";
            }
        }

        public void Reservar() // Verificar Método
        {
            if (StatusEmprestimo == "Reservada")
            {
                return;
            }
            else
            {
                StatusEmprestimo = "Reservada";
            }
        }
    }
}
