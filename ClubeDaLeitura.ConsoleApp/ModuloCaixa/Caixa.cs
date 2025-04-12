using System.Data;
using System.Drawing;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa
    {
        public string Etiqueta;
        public Color Cor;
        public int DiasEmprestimo;

        public Caixa(string etiqueta, Color cor, int diasEmprestimo)
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = diasEmprestimo;
        }

        public Caixa(string etiqueta, Color cor) // Sobre Carga para DiasEmprestimo Padrão
        {
            Etiqueta = etiqueta;
            Cor = cor;
            DiasEmprestimo = 7;
        }


        public void ValidarCaixa()
        {
            string caixaEhvalida = "";

            if (Etiqueta.Length > 50)
                caixaEhvalida += "!...A Etiqueda deve conter um texto únido de no maximo 50 caracteres...!";

            if (DiasEmprestimo == null)
                caixaEhvalida += "Você Não Definio valor para o o limite de dias do Emprestimo...(Valor padrão = 7)!";

        }
        // Implementar Validaçoes para: Etiqueta Duplicada, Dias Emprestimo(caso esteja em brando/Usar ou Não, valor padrão)

        public void AdicionarRevista()
        {
            throw new NotImplementedException();
        }


        public void RemoverRevista()
        {
            throw new NotImplementedException();
        }

    }
}
