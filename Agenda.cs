using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aula_32{
    public class Agenda : IAgenda
    {

        List<Contato> contatos = new List<Contato>();

        private const string PATH = "Database/agenda.csv";
        private const string Folder = "C:/Users/User/Desktop/EAD SENAI/EAD DEV/Aula_32/Database";

        public Agenda()
        {
            //Cria o arquivo caso não exista
            if(!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }
            //Cria o arquivo caso não exista
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        /// <summary>
        /// Cadastrar Contatos
        /// </summary>
        /// <param name="_contato"> Contato a ser adicionado à agenda </param>
        public void Cadastrar(Contato _contato)
        {
            contatos.Add(_contato);
            string[] linhas = new string[] { PrepararLinhaCSV(_contato) };
            File.AppendAllLines(PATH, linhas);

        }

        /// <summary>
        ///  Excluir contato
        /// </summary>
        /// <param name="_contato"> contato excluido </param>
        public void Excluir(string _termo)
        {
            // Criamos uma lista de linhas para fazer uma espécie de backup 
            // na memória do sistema
            List<string> linhas = new List<string>();

            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null){
                    linhas.Add(linha);
                }
            }

            linhas.RemoveAll(z => z.Contains(_termo));

            ReescreverCSV(linhas);
        }

        public void Alterar(Contato _contato, Contato _contatoAlterado)
        {
            contatos.Remove(_contato);

            contatos.Add(_contatoAlterado);
        }

        // Adicionar a lista e mostrar
        /// <summary>
        /// Ler lista
        /// </summary>
        public void Listar()
        {
            List<Contato> agendaE = new List<Contato>();

            foreach(Contato c in contatos)
            {

                System.Console.WriteLine($"{c.Nome} - {c.Telefone}");

                agendaE.Add(c);
            }
            agendaE = agendaE.OrderBy(z => z.Nome).ToList();
        }

        /// <summary>
        /// Reescreve o CSV
        /// </summary>
        /// <param name="lines">Lista de linhas</param>
        private void ReescreverCSV(List<string> lines){
            // Criamos uma forma de reescrever o arquivo sem as linhas removidas
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in lines)
                {
                    output.Write(ln+"\n");
                }
            }
        }

        /// <summary>
        /// Preparar linha do csv
        /// </summary>
        /// <param name="c"> contato linha </param>
        /// <returns>linha</returns>
        public string PrepararLinhaCSV(Contato c){
            
            return $"nome={c.Nome};telefone={c.Telefone}";

        }
    }
}