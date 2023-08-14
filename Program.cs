namespace Biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int op = 0;
            bool sair = false;
            GerenciadorDB.MockValues();
            
            do
            {
                Console.Clear();
                Console.WriteLine("1- Cadastrar Livro");
                Console.WriteLine("2- Cadastrar Usuário");
                Console.WriteLine("3- Cadastrar Emprestimo");
                Console.WriteLine("4- Devolver Livro");
                Console.WriteLine("5 - Sair");
                int.TryParse(Console.ReadLine(), out op);

                switch (op)
                {
                    case 1:
                        CadastrarLivro();
                        break;

                    case 2:
                        CadastrarPessoa();
                        break;

                    case 3:
                        CadastrarEmprestimo();
                        break;

                    case 4:
                        DevolverLivro();
                        break;

                    case 5:
                        Console.Clear();
                        sair = true;
                        break;
                }
            } while (!sair);
        }

        public static void CadastrarLivro() 
        {
            try
            {
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
            }catch (Exception ex)
            {
                Console.WriteLine ("ATENÇÃO : NÃO FOI POSSIVEL CADASTRAR O LIVRO!");
            }
            
        }
        public static void CadastrarPessoa() 
        {
            try
            {
                Console.Clear();
                string Nome, Endereco;
                int Idade, Telefone;
                Console.WriteLine("Digite o nome do usuário:");
                Nome = Console.ReadLine();
                Console.WriteLine("Digite a idade do usuário:");
                int.TryParse(Console.ReadLine(), out Idade);
                Console.WriteLine("Digite o endereço do usuário:");
                Endereco = Console.ReadLine();
                Console.WriteLine("Digite o telefone do usuário:");
                int.TryParse(Console.ReadLine(), out Telefone);

                Pessoa pessoas = new(Nome, Idade, Endereco, Telefone);
                GerenciadorDB.SalvarDados(pessoa: pessoas);
            }catch(Exception ex)
            {
                Console.WriteLine("ATENÇÃO : NÃO FOI POSSIVEL CADASTRAR USUÁRIO!");
            }
            
        }
        public static void CadastrarEmprestimo() 
        {
            try
            {
                Console.Clear();
                Console.WriteLine(GerenciadorDB.ListarLivrosEPessoa());

                int codLivro, codPessoa;
                DateTime dataDeEmprestimo;
                Console.WriteLine("Digite o código do livro:");
                int.TryParse(Console.ReadLine(), out codLivro);
                Console.WriteLine("Digite o código do usuário:");
                int.TryParse(Console.ReadLine(), out codPessoa);
                Console.WriteLine("Digite a data do emprestimo:");
                dataDeEmprestimo = DateTime.Parse(Console.ReadLine());

                Emprestimo emprestimos = new(codLivro, codPessoa, dataDeEmprestimo);
                GerenciadorDB.SalvarDados(emprestimo: emprestimos);
            }catch  (Exception ex)
            {
                Console.WriteLine("ATENÇÃO : NÃO FOI POSSIVEL CADASTRAR O EMPRESTIMO!");
            }
            
        }
        public static void DevolverLivro() 
        {
            try
            {
                Console.Clear();
                Console.WriteLine(GerenciadorDB.ListarEmprestimoEPessoa());

                int codEmprestimo;
                Console.WriteLine("Digite o código de emprestimo: ");
                int.TryParse(Console.ReadLine(), out codEmprestimo);

                Emprestimo verificarEmprestimo = GerenciadorDB.GetEmprestimo(codEmprestimo);
                Console.WriteLine(verificarEmprestimo.Devolver());
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ATENÇÃO : NÃO FOI POSSIVEL REALIZAR A DEVOLUÇÃO DO LIVRO!");
            }         
            
        }
    }
}