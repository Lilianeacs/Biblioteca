namespace Biblioteca
{
    internal class Emprestimo
    {
        public DateTime DataDeEmprestimo;
        public DateTime DataDeDevolucao;
        public int CodEmprestimo;
        public Pessoa Leitor;
        public Livro LivroAEmprestar;

        public Emprestimo(int codLivro, int codPessoa, DateTime dataDeEmprestimo)
        {
            CodEmprestimo = GerenciadorDB.IncrementarEmprestimos();
            DataDeEmprestimo = dataDeEmprestimo;
            DataDeDevolucao = DataDeEmprestimo.AddDays(7);
            Leitor = GerenciadorDB.GetPessoa(codPessoa);
            LivroAEmprestar = GerenciadorDB.GetLivro(codLivro);

            // verificar disponibillidade do livro
            if (LivroAEmprestar != null)
            {
                if (LivroAEmprestar.Alugado == true)
                    Console.WriteLine($"O Livro {LivroAEmprestar.Titulo} não está disponivel!");
                else
                    LivroAEmprestar.Alugado = true;
            }    
        }

        public string Devolver()
        {
            string resposta;

            if (DataDeDevolucao < DateTime.Now)
                resposta = $"O livro {LivroAEmprestar.Titulo} foi devolvido por {Leitor.Nome} atrasado!";
            else
                resposta = $"O livro {LivroAEmprestar.Titulo} foi devolvido por {Leitor.Nome} dentro do prazo!";

            LivroAEmprestar.Alugado = false;
            GerenciadorDB.RemoverEmprestimo(CodEmprestimo);

            return resposta;
        }
        

        
    }
}
