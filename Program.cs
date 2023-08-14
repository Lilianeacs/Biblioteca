namespace Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int op = 0;
            bool sair = false;
            //GerenciadorDB.MockValues();
            do
            {
                Console.Clear();
                Console.WriteLine("1- Cadastrar Livro");
                Console.WriteLine("2- Cadastrar Usuário");
                Console.WriteLine("3- Cadastrar Emprestimo");
                Console.WriteLine("4- Devolver Livro");
                Console.WriteLine("5 - Sair");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.Clear();
                        string Titulo, Autor, Categoria, Editora;
                        Console.WriteLine("Digite o titulo do livro:");
                        Titulo = Console.ReadLine();
                        Console.WriteLine("Digite o nome do autor do livro:");
                        Autor = Console.ReadLine();
                        Console.WriteLine("Digite o nome do categoria do livro:");
                        Categoria = Console.ReadLine();
                        Console.WriteLine("Digite o nome do Editora do livro:");
                        Editora = Console.ReadLine();

                        Livro livros = new(Titulo, Autor, Categoria, Editora);
                        GerenciadorDB.SalvarDados(livro: livros);
                        break;

                    case 2:
                        Console.Clear();
                        string Nome, Endereco;
                        int Idade, Telefone;
                        Console.WriteLine("Digite o nome do usuário:");
                        Nome = Console.ReadLine();
                        Console.WriteLine("Digite a idade do usuário:");
                        Idade = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o endereço do usuário:");
                        Endereco = Console.ReadLine();
                        Console.WriteLine("Digite o telefone do usuário:");
                        Telefone = int.Parse(Console.ReadLine());

                        Pessoa pessoas = new(Nome, Idade, Endereco, Telefone);
                        GerenciadorDB.SalvarDados(pessoa: pessoas);
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine(GerenciadorDB.ListarLivrosEPessoa());

                        int codLivro, codPessoa;
                        DateTime dataDeEmprestimo;
                        Console.WriteLine("Digite o código do livro:");
                        codLivro = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o código do usuário:");
                        codPessoa = int.Parse(Console.ReadLine());
                        Console.WriteLine("Digite a data do emprestimo:");
                        dataDeEmprestimo = DateTime.Parse(Console.ReadLine());

                        Emprestimo emprestimos = new(codLivro, codPessoa, dataDeEmprestimo);
                        GerenciadorDB.SalvarDados(emprestimo: emprestimos);
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine(GerenciadorDB.ListarEmprestimoEPessoa());

                        int codEmprestimo;
                        Console.WriteLine("Digite o código de emprestimo: ");
                        codEmprestimo = int.Parse(Console.ReadLine());

                        Emprestimo verificarEmprestimo = GerenciadorDB.GetEmprestimo(codEmprestimo);
                        Console.WriteLine(verificarEmprestimo.Devolver());
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        sair = true;
                        break;
                }
            } while (!sair);
        }
    }
}