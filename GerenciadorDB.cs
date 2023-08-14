using System.Text;

namespace Biblioteca
{
    internal class GerenciadorDB
    {
        public static Dictionary<int, Pessoa> dbPessoas = new Dictionary<int, Pessoa>();
        public static Dictionary<int, Livro> dbLivros = new Dictionary<int, Livro>();
        public static Dictionary<int, Emprestimo> dbEmprestimos = new Dictionary<int, Emprestimo>();

        public static void SalvarDados(Pessoa pessoa = null, Livro livro = null, Emprestimo emprestimo = null)
        {
            if (pessoa != null)
                dbPessoas.Add(pessoa.CodPessoa, pessoa);
            if (livro != null)
                dbLivros.Add(livro.CodLivro, livro);
            if (emprestimo != null)
                dbEmprestimos.Add(emprestimo.CodEmprestimo, emprestimo);
        }

        public static string ListarLivrosEPessoa()
        {
            StringBuilder stringExibicao = new StringBuilder();
            for (int i = 1, j = 1; i <= dbLivros.Count || j <= dbPessoas.Count; i++, j++)
            {
                if (i <= dbLivros.Count && j <= dbPessoas.Count)
                    stringExibicao.AppendLine(dbLivros[i].CodLivro + " - " + dbLivros[i].Titulo + "\t" + dbPessoas[j].CodPessoa + " - " + dbPessoas[j].Nome);
                else if (i <= dbLivros.Count)
                    stringExibicao.AppendLine(dbLivros[i].CodLivro + " - " + dbLivros[i].Titulo);
                else if (j <= dbPessoas.Count)
                    stringExibicao.AppendLine("\t\t\t" + dbPessoas[j].CodPessoa + " - " + dbPessoas[j].Nome);
            }
            return stringExibicao.ToString();
        }

        public static string ListarEmprestimoEPessoa()
        {
            StringBuilder stringExibicao = new StringBuilder();
            for (int i = 1; i <= dbEmprestimos.Count; i++)
                stringExibicao.AppendLine(dbEmprestimos[i].CodEmprestimo + " - " + dbEmprestimos[i].Leitor.Nome + " | " + dbEmprestimos[i].LivroAEmprestar.Titulo);

            return stringExibicao.ToString();
        }

        public static Livro GetLivro(int codLivro)
        {
            if (dbLivros.ContainsKey(codLivro))
                return dbLivros[codLivro];
            else
                return null;
        }

        public static Pessoa GetPessoa(int codPessoa)
        {
            if (dbPessoas.ContainsKey(codPessoa))
                return dbPessoas[codPessoa];
            else
                return null;
        }

        public static Emprestimo GetEmprestimo(int codEmprestimo)
        {
            if (dbEmprestimos.ContainsKey(codEmprestimo))
                return dbEmprestimos[codEmprestimo];
            else
                return null;
        }

        public static void RemoverEmprestimo(int codEmprestimo)
        {
            if(dbEmprestimos.ContainsKey(codEmprestimo))
                dbEmprestimos.Remove(codEmprestimo);
        }

        public static int IncrementarPessoas() => dbPessoas.LastOrDefault().Key + 1;
        public static int IncrementarLivros() => dbLivros.LastOrDefault().Key + 1;
        public static int IncrementarEmprestimos() => dbEmprestimos.LastOrDefault().Key + 1;

        public static void MockValues()
        {
            Livro livro;
            livro = new Livro("O Senhor dos Anéis", "Fantasia", "J.R.R. Tolkien", "");
            SalvarDados(livro: livro);
            livro = new Livro("1984", "Ficção", "George Orwell", "");
            SalvarDados(livro: livro);
            livro = new Livro("Orgulho e Preconceito", "Romance", "Jane Austen", "");
            SalvarDados(livro: livro);

            Pessoa pessoa;
            pessoa = new Pessoa("João", 30, "Rua A", 123456789);
            SalvarDados(pessoa: pessoa);
            pessoa = new Pessoa("Maria", 31, "Rua B", 987654321);
            SalvarDados(pessoa: pessoa);
            pessoa = new Pessoa("Paula", 32, "Rua C", 112233445);
            SalvarDados(pessoa: pessoa);
        }
    }
}
