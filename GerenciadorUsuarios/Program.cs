using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorUsuarios
{
    // Classe para definir um usuário
    public class Usuario
    {
        // Armazena o nome do usuário
        public string Nome { get; set; }
        // Armazena o e-mail do usuário
        public string Email { get; set; }
        // Armazena a idade do usuário
        public int Idade { get; set; }

        // Define os valores das propriedades da claasse Usuario
        public Usuario(string nome, string email, int idade)
        {
            Nome = nome;
            Email = email;
            Idade = idade;
        }

        // Mostra as informações do usuário de forma formatada
        public override string ToString() => $"Nome: {Nome}, Email: {Email}, Idade: {Idade}";
    }

    class Program
    {
        // Lista para armazenar os usuários em memória enquanto o programa é executado
        private static readonly List<Usuario> usuarios = new List<Usuario>();

        // Método principal
        static void Main(string[] args)
        {
            // Loop infinito para manter o menu em funcionamento até que a opção sair seja selecionada
            while (true)
            {
                // Exibe o menu principal
                ExibirMenu();
                // Lê a opção digitada pelo usuário e remove espaços extras
                string opcao = Console.ReadLine()?.Trim();
                // Estrutura de decisão para direcionar a ação com base na opção escolhida
                switch (opcao)
                {
                    case "1":
                        // Chama o método para cadastrar um novo usuário
                        CadastrarUsuario();
                        break;
                    case "2":
                        // Chama o método para listar todos os usuários cadastrados
                        ListarUsuarios();
                        break;
                    case "3":
                        // Chama o método para buscar um usuário pelo nome
                        BuscarUsuario();
                        break;
                    case "4":
                        // Exibe mensagem de saída e encerra o programa
                        Console.WriteLine("Saindo do sistema...");
                        return;
                    default:
                        // Informa ao usuário que a opção digitada não é válida
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                
                // Pausa a execução para que o usuário possa visualizar o resultado antes de voltar ao menu
                AguardarContinuacao();
            }
        }

        // Exibe o menu principal
        private static void ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine("== Sistema para Cadastro de Usuários ==");
            Console.WriteLine("1. Cadastrar Usuário");
            Console.WriteLine("2. Listar Usuários");
            Console.WriteLine("3. Buscar Usuário");
            Console.WriteLine("4. Sair");
            // Solicita a entrada do usuário
            Console.Write("Escolha uma opção: ");
        }

        // Método para cadastrar um usuário com validação
        private static void CadastrarUsuario()
        {
           // Limpa o console para exibir a tela de cadastro
            Console.Clear();
            Console.WriteLine("== Cadastrar Usuário ==");

            string nome = LerEntrada("Nome: ");
            // Verifica se o nome é usado é válido
            if (string.IsNullOrWhiteSpace(nome))
            {
                // Retorna ao menu se a validação falhar
                Console.WriteLine("Nome inválido!");
                return;
            }

            string email = LerEntrada("Email: ");
            // Verifica se o email tem "@" como validação básica necessária
            if (!email.Contains("@"))
            {
                Console.WriteLine("Email inválido!");
                return;
            }

            if (!int.TryParse(LerEntrada("Idade: "), out int idade) || idade < 0)
            {
                Console.WriteLine("Idade inválida!");
                return;
            }

            // Cria um novo Usuario e adiciona à lista
            usuarios.Add(new Usuario(nome, email, idade));
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }

        // Método para listar todos os usuários
        private static void ListarUsuarios()
        {
            Console.Clear();
            Console.WriteLine("== Lista de Usuários ==");

            // Verifica se a lista está vazia
            if (!usuarios.Any())
            {
                // Volta ao menu se não houver usuários
                Console.WriteLine("Nenhum usuário cadastrado.");
                return;
            }

            foreach (var usuario in usuarios)
            {
                Console.WriteLine(usuario);
            }
        }

        // Método para buscar um usuário pelo nome
        private static void BuscarUsuario()
        {
            Console.Clear();
            Console.WriteLine("== Buscar Usuário ==");

            string nomeBusca = LerEntrada("Digite o nome do usuário: ");
            var usuario = usuarios.FirstOrDefault(u => u.Nome.Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine(usuario != null ? $"Usuário encontrado: {usuario}" : "Usuário não encontrado.");
        }

        // Método auxiliar para a leitura de entrada
        private static string LerEntrada(string mensagem)
        {
            Console.Write(mensagem);
            return Console.ReadLine()?.Trim();
        }

        // Método auxiliar para pausar a execução
        private static void AguardarContinuacao()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}