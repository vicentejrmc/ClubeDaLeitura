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
        public Caixa[] caixa = new Caixa[100];
        int contCaixa = 0;

        public void Inserir()
        {
            throw new NotImplementedException();
        }

        public void Editar()
        { 
            throw new NotImplementedException();
        }

        public void Excluir()
        {
            throw new NotImplementedException();
        }

        public void SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        public void SelecionarPorId()
        {
            throw new NotImplementedException();
        }

        public bool VerificarCor(Color cor)
        {
            for (int i = 0; i < caixa.Length; i++)
            {
                if(cor == caixa[i].CorCaixa)
                {
                    Console.WriteLine(" Está cor já está em uso! escolha outra");

                    return false;
                }
            }

            return true;

        }
    }
}
