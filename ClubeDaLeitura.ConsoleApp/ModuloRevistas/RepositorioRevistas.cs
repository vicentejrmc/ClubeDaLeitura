using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas
{
    public class RepositorioRevistas
    {

        public Revistas[] vetorRevista = new Revistas[100];
        public int contRevista = 0;

        public void CadastrarRevista(Revistas novaRevista)
        {
            vetorRevista[contRevista++] = novaRevista;

            novaRevista.IdRevista = GeradorDeId.GerarIdRevista();
           
        }

        public bool Editar(int id, Revistas novaRevista)
        {
            for (int i = 0; i < vetorRevista.Length; i++)
            {
                if (vetorRevista[i] == null)
                    continue;

                if (vetorRevista[i].IdRevista == id)
                {
                    vetorRevista[i].TituloRevista = novaRevista.TituloRevista;
                    vetorRevista[i].NumEdicao = novaRevista.NumEdicao;
                    vetorRevista[i].AnoEdicao = novaRevista.AnoEdicao;
                    vetorRevista[i].CaixaAtual = novaRevista.CaixaAtual;
                    vetorRevista[i].StatusEmprestimo = novaRevista.StatusEmprestimo;

                    return true;
                }
            }

            return false;
        }

        //public bool Excluir(int excluirCaixa)
        //{
        //    for (int i = 0; i < vetorRevista.Length; i++)
        //    {
        //        if (vetorRevista[i] == null)
        //            continue;

        //        else if (vetorRevista[i].IdRevista == excluirCaixa)
        //        {
        //            vetorRevista[i] = null;

        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public Revistas[] SelecionarRevistas()
        {
            return vetorRevista;
        }

        public void VisualizarRevistas()
        {
            

        }

        public Revistas SelecionarPorId(int idRevista)
        {
            for (int i = 0; i < vetorRevista.Length; i++)
            {
                Revistas obterIdRevista = vetorRevista[i];
                if (obterIdRevista == null) continue;

                else if (obterIdRevista.IdRevista == idRevista)
                    return obterIdRevista;
            }

            return null;
        }
    }

}

    