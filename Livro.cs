namespace Biblioteca
{
    internal class Livro
    {
        public int CodLivro;
        public string Titulo;
        public string Categoria;
        public string Autor;
        public string Editora;

        public Livro(string Titulo, string Categoria, string Autor, string Editora)
        {
            CodLivro = GerenciadorDB.IncrementarLivros();
            this.Titulo = Titulo;
            this.Categoria = Categoria;
            this.Autor = Autor;
            this.Editora = Editora;
        }
        // verificar disponibillidade do livro
    }
}
