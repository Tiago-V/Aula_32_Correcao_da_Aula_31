using System;

namespace Aula_32
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciar agenda
            Agenda agenda1 = new Agenda();

            // Instanciar  Mensagem
            Mensagem msg = new Mensagem();

            // Instanciar Contatos
            Contato c1 = new Contato("Pedro", "+55 11 997849031");
            Contato c2 = new Contato("Tiago", "+55 11 997849032");
            Contato c3 = new Contato("Joao ", "+55 11 997849033");
            Contato c4 = new Contato("Maria", "+55 11 997849034");

            // Adicionar Contatos
            agenda1.Cadastrar(c1);
            agenda1.Cadastrar(c2);
            agenda1.Cadastrar(c3);
            agenda1.Cadastrar(c4);

            // Listar // Ler
            agenda1.Listar();

            // Excluir
            agenda1.Excluir("Maria");

            // Alterar Contato
            Contato c5 = new Contato("Hagi ", "+55 11 994693241");

            agenda1.Alterar(c2, c5);

            agenda1.Cadastrar(c5);

            // Pular linha
            System.Console.WriteLine();
            // Pular linha

            // Ler novamente
            agenda1.Listar();

            // Pular linha
            System.Console.WriteLine();
            // Pular linha

            // Escrever uma mensagem.
            Console.WriteLine(msg.Enviar(c2));

        }
    }
}
