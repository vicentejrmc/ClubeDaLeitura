
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloReservas;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClubeDaLeitura.ConsoleApp.Compatilhado
{
    public class ContextoDados
    {
        public List<Amigo> Amigos { get; set; }
        public List<Caixa> Caixas { get; set; }
        public List<Revista> Revistas { get; set; }
        public List<Emprestimo> Emprestimos { get; set; }

        public List<Reserva> Reservas { get; set; }

        private string pastaArmazenamento = "F:\\ArquivosJson";
        private string arquivoArmazenamento = "dados.json";

        public ContextoDados()
        {
            Amigos = new List<Amigo>();
            Caixas = new List<Caixa>();
            Revistas = new List<Revista>();
            Emprestimos = new List<Emprestimo>();
            Reservas = new List<Reserva>();
        }

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados)
                Carregar();
        }

        private void Carregar()
        {
            string caminho = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            if (!File.Exists(caminho)) return;  // Verificação de existencia de arquivo

            string json = File.ReadAllText(caminho);

            if(string.IsNullOrWhiteSpace(json)) return; // Verificação de arquivo

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            ContextoDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(json, jsonOptions)!;

            if(contextoArmazenado == null) return;

            this.Amigos = contextoArmazenado.Amigos;
            this.Caixas = contextoArmazenado.Caixas;
            this.Revistas = contextoArmazenado.Revistas;
            this.Emprestimos = contextoArmazenado.Emprestimos;
            this.Reservas = contextoArmazenado.Reservas;
        }

        public void Salvar()
        {
            string caminho = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            // configuração
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions(); 
            jsonOptions.WriteIndented = true;
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            string json = JsonSerializer.Serialize(this, jsonOptions);

            if(!Directory.Exists(pastaArmazenamento))  // verificação de arquivo
                Directory.CreateDirectory(pastaArmazenamento); // criação caso não exista

            File.WriteAllText(caminho, json); // Escrita.
        }
    }
}