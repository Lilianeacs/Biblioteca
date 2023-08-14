namespace Biblioteca
{
    internal class Pessoa
    {
        public int CodPessoa;
        public int Telefone;
        public string Nome;
        public int Idade;
        public string Endereco;

        public Pessoa(string Nome, int Idade, string Endereco, int Telefone)
        {
            CodPessoa = GerenciadorDB.IncrementarPessoas();
            this.Nome = Nome;
            this.Idade = Idade;
            this.Endereco = Endereco;
            this.Telefone = Telefone;
        }
    }
}
