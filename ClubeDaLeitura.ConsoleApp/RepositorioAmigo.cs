namespace ClubeDaLeitura.ConsoleApp;

public class RepositorioAmigo
{
    Amigo[] vetorDeAmigos = new Amigo[100];



    public void InserirNovoAmigo(Amigo amigo)
    {
        for (int i = 0; i < vetorDeAmigos.Length; i++)
        {
            if (vetorDeAmigos[i] == null)
            {
                vetorDeAmigos[i] = amigo;
                break;
            }
        }
    }

    public void EditarAmigoCadastrado(int id, Amigo amigo)
    {
        for (int i = 0; i < vetorDeAmigos.Length; i++)
        {
            if (vetorDeAmigos[i] != null && vetorDeAmigos[i].Id == id)
            {
                vetorDeAmigos[i] = amigo;
                break;
            }
        }
    }

    public void ExcluirAmigoCadastrado(int id)
    {
        for (int i = 0; i < vetorDeAmigos.Length; i++)
        {
            if (vetorDeAmigos[i] != null && vetorDeAmigos[i].Id == id)
            {
                vetorDeAmigos[i] = null;
                break;
            }
        }
    }

    public void VisualizarAmigosCadastrados()
    {
        Console.WriteLine("Lista de Amigos Cadastrados:");
        Console.WriteLine("-----------------------------------------------------\n");
        for (int i = 0; i < vetorDeAmigos.Length; i++)
        {
            if (vetorDeAmigos[i] != null)
            {
                Console.WriteLine($"ID: {vetorDeAmigos[i].Id}, Nome: {vetorDeAmigos[i].Nome}, Responsável: {vetorDeAmigos[i].Responsavel}, Telefone: {vetorDeAmigos[i].Telefone}");
            }
        }
    }

    public Amigo ObterAmigoPorId(int id)
    {
        for (int i = 0; i < vetorDeAmigos.Length; i++)
        {
            if (vetorDeAmigos[i] != null && vetorDeAmigos[i].Id == id)
            {
                return vetorDeAmigos[i];
            }
        }
        return null;
    }

    public Amigo[] ObterTodosOsAmigos()
    {
        return vetorDeAmigos;
    }

}