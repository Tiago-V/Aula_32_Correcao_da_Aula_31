namespace Aula_32
{
    public class Contato
    {
        // Gerenciar Contatos

        public string Nome { get; set; }
        public string Telefone { get; set; }

        public Contato()
        {

        }
        public Contato(string _nome, string _telefone)
        {
            this.Nome = _nome;
            this.Telefone = _telefone;
        }
    }
}