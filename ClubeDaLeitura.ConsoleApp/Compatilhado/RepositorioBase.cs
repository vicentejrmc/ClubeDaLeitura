using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compatilhado
{
    public abstract class RepositorioBase<T> where T : EntidadeBase<T>
    {
        private List<T> registros = new List<T>();
        private int contadorIds = 0;

        public void CadastrarRegistro(T novoRegistro)
        {
            novoRegistro.Id = ++contadorIds;

            registros.Add(novoRegistro);

        }

        public bool EditarRegistro(int idRegistro, T registroEditado)
        {
            foreach(T entidade in registros)
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
            T registroSelecionado = SelecionarRegistroPorId(idRegistro);

            if (registroSelecionado != null)
            {
                registros.Remove(registroSelecionado);
                return true;
            }

            return false;
        }

        public T SelecionarRegistroPorId(int idRegistro)
        {
            foreach (T entidade in registros)
            {
                if (entidade == null)
                    continue;

                else if (entidade.Id == idRegistro)
                    return entidade;
            }

            return null;
        }

        public List<T> SelecionarTodos()  // Método a ser usado pelos repositorios filhos ao pelo método Visualizar()
        {
            return registros;
        }


    }
}
