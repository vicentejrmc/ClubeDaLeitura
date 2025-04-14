using ClubeDaLeitura.ConsoleApp.Compatilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevistas
{
    public class RepositorioRevista
    {

        public Revista[] vetorRevista = new Revista[100];
        public int contRevista = 0;

        public void CadastrarRevista(Revista novaRevista)
        {
            vetorRevista[contRevista++] = novaRevista;

            novaRevista.IdRevista = GeradorDeId.GerarIdRevista();
           
        }

        public bool Editar(int id, Revista novaRevista)
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
        } //ok

        public bool Excluir(int excluirRevista)
        {
            for (int i = 0; i < vetorRevista.Length; i++)
            {
                if (vetorRevista[i] == null)
                    continue;

                else if (vetorRevista[i].IdRevista == excluirRevista)
                {
                    vetorRevista[i] = null;

                    return true;
                }
            }
            return false;
        }

        public Revista[] SelecionarRevistas()
        {
            return vetorRevista;
        }


        public Revista SelecionarPorId(int idRevista)
        {
            for (int i = 0; i < vetorRevista.Length; i++)
            {
                Revista obterIdRevista = vetorRevista[i];
                if (obterIdRevista == null) continue;

                else if (obterIdRevista.IdRevista == idRevista)
                    return obterIdRevista;
            }

            return null;
        }
    }

}

    