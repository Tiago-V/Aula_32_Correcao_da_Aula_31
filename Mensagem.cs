using System.IO;

namespace Aula_32
{
    public class Mensagem
    {
        public string Texto { get; set; }
        
        public Contato Destinatario { get; set; } 

        private const string PATH = "Database/mensagens.csv";
        public Mensagem(){
            //Cria o arquivo caso não exista
            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        }

        /// <summary>
        /// Enviar mensagem
        /// </summary>
        /// <param name="_contato"> Contato para quem a mensagem será enviada </param>
        /// <returns> mensagem enviada </returns>
        public string Enviar(Contato _contato)
        {
            Destinatario = _contato;
            
            Texto = System.Console.ReadLine();

            string[] linhas = new string[] { PrepararLinhaCSV(_contato) };
            File.AppendAllLines(PATH, linhas);

            return $"Texto: {Texto}\nPara: {Destinatario.Nome} - {Destinatario.Telefone}";
        }
        public string PrepararLinhaCSV(Contato c){
            
            return $"texto={Texto};nomecontato={Destinatario.Nome};telefonecontato={Destinatario.Telefone};";

        }
    }
}