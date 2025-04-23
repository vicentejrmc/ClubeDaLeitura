using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compatilhado
{
    public abstract class RepositorioBase
    {
        private ArrayList registros = new ArrayList();
        private int contadorIds = 0;

        public void CadastrarRegistro(EntidadeBase novoRegistro)
        {
            novoRegistro.Id = ++contadorIds;

            registros.Add(novoRegistro);

        }

        public bool EditarRegistro(int idRegistro, EntidadeBase registroEditado)
        {
            foreach(EntidadeBase entidade in registros)
            {
                if(entidade.Id == idRegistro)
                {
                    entidade.AtualizarRegistro(registroEditado);

                    return true;
                }
            }

            return false;
        }

        public bool ExcluirRegistro(int idRegistro)
        {
            EntidadeBase registroSelecionado = SelecionarRegistroPorId(idRegistro);

            if (registroSelecionado != null)
            {
                registros.Remove(registroSelecionado);
                return true;
            }

            return false;
        }

        public EntidadeBase SelecionarRegistroPorId(int idRegistro)
        {
            foreach (EntidadeBase entidade in registros)
            {
                if (entidade == null)
                    continue;

                else if (entidade.Id == idRegistro)
                    return entidade;
            }

            return null;
        }

        public ArrayList SelecionarTodos()  // Método a ser usado pelos repositorios filhos ao pelo método Visualizar()
        {
            return registros;
        }


    }
}
