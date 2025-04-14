using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class RepositorioCaixa
    {
        public Caixa[] vetorDeCaixa = new Caixa[100];
        int contCaixa = 0;

        public void Inserir(Caixa novaCaixa)
        {
            vetorDeCaixa[contCaixa++] = novaCaixa;

            novaCaixa.IdCaixa = GeradorDeId.GerarIdCaixa();
        }

        public bool Editar(int id, Caixa caixaEditada)
        {
            for (int i = 0; i < vetorDeCaixa.Length; i++)
            {
                if (vetorDeCaixa[i] == null)
                    continue;

                if (vetorDeCaixa[i].IdCaixa == id)
                {
                    vetorDeCaixa[i].Etiqueta = caixaEditada.Etiqueta;
                    vetorDeCaixa[i].DiasEmprestimo = caixaEditada.DiasEmprestimo;
                    vetorDeCaixa[i].CorCaixa = caixaEditada.CorCaixa;

                    return true;
                }
            }

            return false;
        }

        public bool Excluir(int excluirCaixa)
        {
            for (int i = 0; i < vetorDeCaixa.Length; i++)
            {
                if (vetorDeCaixa[i] == null)
                    continue;

                else if (vetorDeCaixa[i].IdCaixa == excluirCaixa)
                {
                    vetorDeCaixa[i] = null;

                    return true;
                }
            }
            return false;
        }

        public void SelecionarTodos()
        {
            Console.WriteLine("{0 , -15} | {0, -20} | {0, -15} | {0, -20}",
                        "Id Caixa", "Etiqueta", "Cor");
            for (int i = 0; i < vetorDeCaixa.Length; i++)
            {
                Caixa[] caixaCadastrada = SelcionarCaixa();
                Caixa cx = caixaCadastrada[i];

                if (vetorDeCaixa[i] != null)
                {
                    Console.WriteLine("{0 , -15} | {0, -20} | {0, -15} | {0, -20}",
                     cx.IdCaixa, cx.Etiqueta, cx.CorCaixa);             
                }
            }
            Console.WriteLine();
        }

        public Caixa SelecionarPorId(int idCaixa)
        {
            for (int i = 0; i < vetorDeCaixa.Length; i++)
            {
                Caixa obterCaixaID = vetorDeCaixa[i];
                if (obterCaixaID == null) continue;

                else if (obterCaixaID.IdCaixa == idCaixa)
                    return obterCaixaID;
            }

            return null;
        }

        public Caixa[] SelcionarCaixa()
        {
            return vetorDeCaixa;
        }
    }
}
