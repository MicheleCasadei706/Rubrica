using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casadei.Michele._4i.rubricaUnoAMolti
{
    public class Persona
    {
        public int idPersona { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Persona(string riga)
        {
            string[] values = riga.Split(';');

            if(values.Count() != 3)
                throw new Exception("Le righe di persone.csv devono essere di tre colonne");

            if(int.TryParse(values[0], out int id))
            {
                this.idPersona = id;
                this.Nome = values[1];
                this.Cognome = values[2];
            }
        }
    }
    public class Persone : List<Persona>
    {
        public Persone() { }
        public Persone(string nomeFile)
        {

            StreamReader fin = new StreamReader(nomeFile);
            fin.ReadLine();

            while (!fin.EndOfStream)
            {
                Add(new Persona(fin.ReadLine()));
            }
            fin.Close();
        }
    }
}