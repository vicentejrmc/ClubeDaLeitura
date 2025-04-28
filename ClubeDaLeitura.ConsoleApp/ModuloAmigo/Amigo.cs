using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class Amigo : EntidadeBase<Amigo>
    {
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public string Telefone { get; set; }
        public string status { get; set; }

        public double Multa { get; set; }

        public Amigo(string nome, string responsavel, string telefone) // Construtor amigo
        {
            Nome = nome;
            Responsavel = responsavel;
            Telefone = telefone;
        }

        public override void AtualizarRegistro(Amigo resgitroEditado)
        {
            Amigo amigoEditado = (Amigo)resgitroEditado;

            Nome = amigoEditado.Nome;
            Responsavel = amigoEditado.Responsavel;
            Telefone = amigoEditado.Telefone;
        }

        public override string Validar()
        {
            string errosValidacao = "";

            if(String.IsNullOrWhiteSpace(Nome))
                errosValidacao += "Erro! O nome não pode ser vazio.\n";

            if (String.IsNullOrWhiteSpace(Responsavel))
                errosValidacao += "Erro! O nome do responsável não pode ser vazio.\n";

            if (String.IsNullOrWhiteSpace(Telefone))
                errosValidacao += "Erro! O telefone não pode ser vazio.\n";

            if (Nome.Length < 3 || Nome.Length > 100)
                errosValidacao += "Erro! O nome deve ter entre 3 e 100 caracteres.\n";

            if (Responsavel.Length < 3 || Responsavel.Length > 100)
                errosValidacao += "Erro! O nome do responsável deve ter entre 3 e 100 caracteres.\n";

            if (Telefone.Length < 11 || Telefone.Length > 13) 
                errosValidacao += "Erro! O telefone deve estar no formato XX XXXX-XXXX ou XX XXXXX-XXXX\n";


            //Não permitir excluir um amigo caso tenha empréstimos vinculados

            return errosValidacao;
        }

        public void AdicionarMulta(Amigo amigo, double valor)
        {
            amigo.status = "Bloqueado";
            amigo.Multa = valor;
        }

    }
}
