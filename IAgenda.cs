namespace Aula_32
{
    public interface IAgenda
    {
        // CRUD

        void Cadastrar(Contato _contato);
        void Excluir(string _termo);
        void Alterar(Contato _contato, Contato _contatoAlterado);
        void Listar();
    }
}